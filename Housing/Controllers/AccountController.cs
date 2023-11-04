using AutoMapper;
using Housing.Data;
using Housing.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        private readonly UserManager<ApiUser> _userManager;
        //private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager, ILogger<AccountController> logger, IMapper mapper)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            _logger.LogInformation($"Registration Attempt for {userDto.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.Email;
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRolesAsync(user, userDto.Roles);

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }




        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginUserDTO userDto)
        //{
        //    _logger.LogInformation($"Login Attempt for {userDto.EmailAddress}");

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var result= await _signInManager.PasswordSignInAsync(userDto.EmailAddress, userDto.Password,false,false)
        //        if (!result.Succeeded)
        //        {
        //            return Unauthorized(userDto);
        //        }

        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something went wrong in the {nameof(Login)}");
        //        return StatusCode(500, "Internal Server Error. Please try again later.");
        //    }
        //}
    }
}

