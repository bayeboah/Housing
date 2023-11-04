using AutoMapper;
using Housing.Model;
using Housing.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HouseController> _logger;
        private IMapper _mapper;

        public HouseController(IUnitOfWork unitOfWork, ILogger<HouseController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetHouses()
        {
            try
            {
                var houses = await _unitOfWork.Houses.GetAll();
                var results = _mapper.Map<IList<HouseDTO>>(houses);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHouses)}");
                return StatusCode(500, "Internal server Error.Please try again later");
            }
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHouse(int id)
        {
            try
            {
                var house = await _unitOfWork.Houses.Get(q => q.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<HouseDTO>(house);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHouse)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

    }
}
