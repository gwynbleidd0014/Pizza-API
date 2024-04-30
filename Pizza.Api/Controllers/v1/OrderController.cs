using Microsoft.AspNetCore.Mvc;
using Pizza.Api.Infrastructure.Examples.Order;
using Pizza.Api.Infrastructure.Examples.Pizza;
using Pizza.Application.Services.CommonServiceInterface;
using Pizza.Application.Services.OrderSM;
using PizzaSM.Application.Services.Pizza;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(OrderResponseExample))]
        public async Task<ActionResult<List<OrderResponseModel>>> GetAll() 
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(OrderResponseExample))]
        public async Task<ActionResult<OrderResponseModel>> Get(string id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [SwaggerRequestExample(typeof(OrderRequestModel), typeof(OrderRequestExample))]
        public async Task<IActionResult> Create([FromBody] OrderRequestModel model)
        { 
            await _service.Create(model);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
