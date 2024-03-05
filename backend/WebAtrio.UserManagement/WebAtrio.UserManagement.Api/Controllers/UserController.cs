using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAtrio.UserManagement.Business;
using WebAtrio.UserManagement.Models.DTO;

namespace WebAtrio.UserManagement.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(UserDto), 201)]
        [SwaggerOperation(Summary = "Add a new user", Description = "Adds a new user to the system.")]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            UserDto addedUser = await _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = addedUser.Id }, addedUser);
        }

        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [SwaggerOperation(Summary = "Get user by ID", Description = "Retrieves a user by their unique identifier.")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            UserDto user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        [SwaggerOperation(Summary = "Get all users", Description = "Retrieves all users from the system.")]
        public async Task<IActionResult> GetUsers()
        {
            List<UserDto> users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [SwaggerOperation(Summary = "Update user", Description = "Updates an existing user in the system.")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            UserDto updatedUser = await _userService.UpdateUser(userDto);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [SwaggerOperation(Summary = "Delete user", Description = "Deletes an existing user from the system.")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            UserDto deletedUser = await _userService.DeleteUser(id);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser);
        }
    }
}
