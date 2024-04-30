using Microsoft.AspNetCore.Mvc;
using Pizza.Api.Infrastructure.Examples.Address;
using Pizza.Api.Infrastructure.Examples.Pizza;
using Pizza.Application.Services.AddressSM;
using Pizza.Application.Services.CommonServiceInterface;
using Pizza.Application.Services.PizzaSM;
using PizzaSM.Application.Services.Pizza;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PizzaController : ControllerBase
    {
        private readonly ICrudService<PizzaRequestModel, PizzaResponseModel, PizzaUpdateModel> _service;

        public PizzaController(ICrudService<PizzaRequestModel, PizzaResponseModel, PizzaUpdateModel> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(PizzaResponseExample))]
        public async Task<ActionResult<List<PizzaResponseModel>>> GetAll() {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(PizzaResponseExample))]
        public async Task<ActionResult<PizzaResponseModel>> Get(string id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [SwaggerRequestExample(typeof(PizzaRequestModel), typeof(PizzaRequestExample))]
        public async Task<IActionResult> Create([FromBody] PizzaRequestModel pizza)
        {
            await _service.Create(pizza);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpPut]
        [ProducesResponseType(202)]
        [SwaggerRequestExample(typeof(PizzaRequestModel), typeof(PizzaRequestExample))]
        public async Task<IActionResult> Update([FromBody] PizzaUpdateModel model)
        {
            await _service.Update(model);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
   
}
