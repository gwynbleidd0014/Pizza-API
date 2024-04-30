using Microsoft.AspNetCore.Mvc;
using Pizza.Api.Infrastructure.Examples;
using Pizza.Api.Infrastructure.Examples.User;
using Pizza.Application.Services.AddressSM;
using Pizza.Application.Services.CommonServiceInterface;
using Pizza.Application.Services.UserSM;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly ICrudService<UserRequestModel, UserResponseModel, UserUpdateModel> _service;

        public UserController(ICrudService<UserRequestModel, UserResponseModel, UserUpdateModel> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(UserResponseExample))]
        public async Task<ActionResult<List<UserResponseModel>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [SwaggerResponseExample(200, typeof(UserResponseExample))]
        public async Task<ActionResult<UserResponseModel>> Get(string id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [SwaggerRequestExample(typeof(UserRequestModel), typeof(UserRequestExample))]
        public async Task<IActionResult> Create([FromBody] UserRequestModel model)
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
        [SwaggerRequestExample(typeof(UserUpdateModel), typeof(UserUpdateExample))]
        public async Task<IActionResult> Update([FromBody] UserUpdateModel model)
        {
            await _service.Update(model);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
