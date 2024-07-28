using Management.Contracts.DTO;
using Management.Contracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _teamService.GetTeamAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamRequest request)
        {
            if (string.IsNullOrEmpty(request.TeamName) || string.IsNullOrEmpty(request.TeamDescription))
            {
                return BadRequest("Team name and description are required.");
            }

            var team = await _teamService.CreateTeamAsync(request.TeamName, request.TeamDescription);
            return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] UpdateTeamRequest request)
        {
            if (string.IsNullOrEmpty(request.TeamName) || string.IsNullOrEmpty(request.TeamDescription))
            {
                return BadRequest("Team name and description are required.");
            }

            var team = await _teamService.UpdateTeamAsync(id, request.TeamName, request.TeamDescription);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _teamService.DeleteTeamAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }
    }

}
