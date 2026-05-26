using Diet.Tracking.API.Abstractions.Services;
using Diet.Tracking.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Diet.Tracking.API.Domain.Exceptions;

namespace Diet.Tracking.API.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 204)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _userService.GetAllAsync());
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 204)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            if (id < 1)
                throw new ValidationException(422, "Id must be informed");
            
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserModel), 201)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 401)]
        [ProducesResponseType(typeof(ErrorModel), 403)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        public async Task<IActionResult> CreateAsync([FromBody] UserModel user)
        {
            user.Validate();
            return Created(string.Empty, await _userService.CreateAsync(user));
        }

        [HttpPatch]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 401)]
        [ProducesResponseType(typeof(ErrorModel), 403)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        public async Task<IActionResult> UpdateAsync([FromBody] UserModel user)
        {
            user.Validate();
            await _userService.UpdateAsync(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 401)]
        [ProducesResponseType(typeof(ErrorModel), 403)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (id < 1)
                throw new ValidationException(422, "Id must be informed");
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
