using Management.Contracts.DTO;
using Management.Contracts.Interface;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public UserTaskController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> GetUserTask(int id)
        {
            var userTask = await _userTaskService.GetUserTaskAsync(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return userTask;
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<List<UserTask>>> GetUserTaskListByTeam(int teamId)
        {
            var userTasks = await _userTaskService.GetUserTaskListByTeamAsync(teamId);
            return Ok(userTasks);
        }

        [HttpPost]
        public async Task<ActionResult<UserTask>> CreateUserTask([FromBody] CreateUserTaskRequest request)
        {
            var userTask = await _userTaskService.CreateUserTask(request.Title, request.Description, request.TeamId, request.DueDate, request.Priority);
            return CreatedAtAction(nameof(GetUserTask), new { id = userTask.TaskId }, userTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserTask>> UpdateUserTask(int id, [FromBody] UserTask userTask)
        {
            if (id != userTask.TaskId)
            {
                return BadRequest();
            }

            var updatedUserTask = await _userTaskService.UpdateUserTaskAsync(userTask);
            return Ok(updatedUserTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTask>> DeleteUserTask(int id)
        {
            var userTask = await _userTaskService.DeleteUserTaskAsync(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return Ok(userTask);
        }
    }
}
