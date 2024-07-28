using Management.Contracts.DTO;
using Management.Contracts.Interface;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskRequiredActionController : ControllerBase
    {
        private readonly ITaskRequiredAction _taskRequiredActionService;

        public TaskRequiredActionController(ITaskRequiredAction taskRequiredActionService)
        {
            _taskRequiredActionService = taskRequiredActionService;
        }

        [HttpGet("task/{taskId}")]
        public async Task<ActionResult<List<TaskRequiredAction>>> GetRequiredActionsByTaskId(int taskId)
        {
            var actions = await _taskRequiredActionService.GetRequiredActionsByTaskIdAsync(taskId);
            return Ok(actions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskRequiredAction>> GetRequiredAction(int id)
        {
            var action = await _taskRequiredActionService.GetRequiredActionAsync(id);
            if (action == null)
            {
                return NotFound();
            }
            return Ok(action);
        }

        [HttpPost]
        public async Task<ActionResult<TaskRequiredAction>> CreateRequiredAction([FromBody] CreateRequiredActionRequest request)
        {
            var action = await _taskRequiredActionService.CreateRequiredAction(request.TaskId, request.ActionType, request.DueDate, request.Status);
            return CreatedAtAction(nameof(GetRequiredAction), new { id = action.ActionId }, action);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskRequiredAction>> UpdateRequiredAction(int id, [FromBody] TaskRequiredAction action)
        {
            if (id != action.ActionId)
            {
                return BadRequest();
            }

            var updatedAction = await _taskRequiredActionService.UpdateRequiredActionAsync(action);

            if (updatedAction == null)
            {
                return NotFound();
            }

            return Ok(updatedAction);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskRequiredAction>> DeleteRequiredAction(int id)
        {
            var action = await _taskRequiredActionService.DeleteRequiredActionAsync(id);
            if (action == null)
            {
                return NotFound();
            }
            return Ok(action);
        }
    }
}
