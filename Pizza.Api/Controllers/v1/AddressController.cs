using Microsoft.AspNetCore.Mvc;
using Pizza.Api.Infrastructure.Examples.Address;
using Pizza.Api.Infrastructure.Examples.User;
using Pizza.Application.Services.AddressSM;
using Pizza.Application.Services.CommonServiceInterface;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AddressController : ControllerBase
    {
        private readonly ICrudService<AddressRequestModel, AddressResponseModel, AddressUpdateModel> _service;

        public AddressController(ICrudService<AddressRequestModel, AddressResponseModel, AddressUpdateModel> service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(AddressResponseExample))]
        public async Task<ActionResult<List<AddressResponseModel>>> GetAll() {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(AddressResponseExample))]
        public async Task<ActionResult<AddressResponseModel>> Get(string id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [SwaggerRequestExample(typeof(AddressResponseModel), typeof(AddressResponseExample))]
        public async Task<IActionResult> Create([FromBody] AddressRequestModel model)
        { 
            await _service.Create(model);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Delete(string id)
        { 
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpPut]
        [ProducesResponseType(202)]
        [SwaggerRequestExample(typeof(AddressUpdateModel), typeof(AddressUpdateExample))]
        public async Task<IActionResult> Update([FromBody] AddressUpdateModel model)
        {
            await _service.Update(model);
            return StatusCode(StatusCodes.Status202Accepted);
        }

    }
}
