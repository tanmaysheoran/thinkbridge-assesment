using Management.Contracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRolesController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignUserRole(int userId, int roleId)
        {
            var userRole = await _userRoleService.AssignUserRoleAsync(userId, roleId);

            if (userRole == null)
            {
                return BadRequest("User role could not be assigned.");
            }

            return Ok(userRole);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserRole(int userId, int roleId)
        {
            var result = await _userRoleService.UpdateUserRoleAsync(userId, roleId);

            if (!result)
            {
                return NotFound("User role could not be updated.");
            }

            return Ok("User role updated successfully.");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUserRole(int userId, int roleId)
        {
            var result = await _userRoleService.DeleteUserRoleAsync(userId, roleId);

            if (!result)
            {
                return NotFound("User role could not be deleted.");
            }

            return Ok("User role deleted successfully.");
        }
    }
}
