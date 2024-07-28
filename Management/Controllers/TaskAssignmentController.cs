using Management.Contracts.DTO;
using Management.Contracts.Interface;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly ITaskAssignmentService _taskAssignmentService;

        public TaskAssignmentController(ITaskAssignmentService taskAssignmentService)
        {
            _taskAssignmentService = taskAssignmentService;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<UserTask>>> GetTasksByUserId(int userId)
        {
            var tasks = await _taskAssignmentService.GetTasksByUserIdAsync(userId);
            if (tasks == null || tasks.Count == 0)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpPost("assign")]
        public async Task<ActionResult> CreateTaskAssignment([FromBody] TaskAssignmentDto taskAssignmentDto)
        {
            var result = await _taskAssignmentService.CreateTaskAssigment(taskAssignmentDto.UserId, taskAssignmentDto.TaskId);
            if (!result)
            {
                return BadRequest("Task assignment creation failed.");
            }
            return Ok();
        }

        [HttpDelete("unassign")]
        public async Task<ActionResult> DeleteTaskAssignment([FromBody] TaskAssignmentDto taskAssignmentDto)
        {
            var result = await _taskAssignmentService.DeleteTaskAssigment(taskAssignmentDto.UserId, taskAssignmentDto.TaskId);
            if (!result)
            {
                return BadRequest("Task assignment deletion failed.");
            }
            return Ok();
        }
    }
}
