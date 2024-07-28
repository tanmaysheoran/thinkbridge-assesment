using Management.Contracts.Interface;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamMembersController : ControllerBase
    {
        private readonly ITeamMemeberService _teamMemberService;

        public TeamMembersController(ITeamMemeberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<List<TeamMember>>> GetTeamMembers(int teamId)
        {
            var teamMembers = await _teamMemberService.GetTeamMembersByTeamIdAsync(teamId);
            return Ok(teamMembers);
        }

        [HttpPost("{teamId}/add")]
        public async Task<ActionResult> AddTeamMember(int teamId, int userId, bool isManager)
        {
            var result = await _teamMemberService.AddTeamMemberAsync(teamId, userId, isManager);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{teamId}/remove")]
        public async Task<ActionResult> RemoveTeamMember(int teamId, int userId)
        {
            var result = await _teamMemberService.RemoveTeamMemberAsync(teamId, userId);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
