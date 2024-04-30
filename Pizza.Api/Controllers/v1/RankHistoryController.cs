using Microsoft.AspNetCore.Mvc;
using Pizza.Api.Infrastructure.Examples.Order;
using Pizza.Api.Infrastructure.Examples.RankHistory;
using Pizza.Application.Services.CommonServiceInterface;
using Pizza.Application.Services.OrderSM;
using Pizza.Application.Services.RankHistory;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RankHistoryController : ControllerBase
    {
        private readonly IRankHistoryService _service;

        public RankHistoryController(IRankHistoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(RankHistoryResponseExample))]
        public async Task<ActionResult<List<RankHistoryResponseModel>>> GetAll()
        { 
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(RankHistoryResponseExample))]
        public async Task<ActionResult<RankHistoryResponseModel>> Get(string id)
        { 
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [SwaggerRequestExample(typeof(RankHistoryRequestModel), typeof(RankHistoryRequestExample))]
        public async Task<IActionResult> Create([FromBody] RankHistoryRequestModel model)
        { 
            await _service.Create(model);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
