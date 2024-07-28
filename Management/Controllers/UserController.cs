using Management.Contracts.DTO;
using Management.Contracts.Interface;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (createUserDto == null)
            {
                return BadRequest();
            }

            var result = await _userService.CreateUserAsync(
                createUserDto.UserName,
                createUserDto.Password,
                createUserDto.FirstName,
                createUserDto.LastName,
                createUserDto.IsAdmin);

            if (result)
            {
                return Ok();
            }

            return Conflict("Username already exists.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var updatedUser = await _userService.UpdateUserAsync(user);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userService.DeleteUserAsync(user);
            if (result)
            {
                return Ok();
            }

            return BadRequest("Unable to delete user.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPatch("status/{id}")]
        public async Task<IActionResult> UpdateUserStatus(int id, [FromBody] UpdateUserStatusDto updateUserStatusDto)
        {
            var result = await _userService.UpdateUserStatusAsync(id, updateUserStatusDto.IsActive);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LogInDto logInDto)
        {
            var userId = await _userService.LogInAsync(logInDto.UserName, logInDto.Password);
            if (userId == null)
            {
                return Unauthorized();
            }
            return Ok(new { UserId = userId });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogOut()
        {
            var result = await _userService.LogOutAsync();
            if (result)
            {
                return Ok();
            }

            return BadRequest("Unable to log out.");
        }
    }
}
