using AutoMapper;
using Housing.Model;
using Housing.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StateController> _logger;
        private IMapper _mapper;

        public StateController(IUnitOfWork unitOfWork, ILogger<StateController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetStates()
        {
            try
            {
                var states = await _unitOfWork.States.GetAll();
                var results = _mapper.Map<IList<StateDTO>>(states);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetStates)}");
                return StatusCode(500, "Internal server Error.Please try again later");
            }
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetState(int id)
        {
            try
            {
                var state = await _unitOfWork.States.Get(q => q.Id == id, new List<string> {"Country"});
                var result = _mapper.Map<StateDTO>(state);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetState)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
