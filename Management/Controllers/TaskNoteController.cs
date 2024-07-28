using Management.Contracts.Interface;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskNotesController : ControllerBase
    {
        private readonly ITaskNoteSerivce _taskNoteService;

        public TaskNotesController(ITaskNoteSerivce taskNoteService)
        {
            _taskNoteService = taskNoteService;
        }

        // GET: api/TaskNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskNote>> GetTaskNote(int id)
        {
            var taskNote = await _taskNoteService.GetTaskNoteAsync(id);
            if (taskNote == null)
            {
                return NotFound();
            }
            return Ok(taskNote);
        }

        // GET: api/TaskNotes/action/5
        [HttpGet("action/{actionId}")]
        public async Task<ActionResult<TaskNote>> GetTaskNoteByActionId(int actionId)
        {
            var taskNote = await _taskNoteService.GetTaskNoteByActionIdAsync(actionId);
            if (taskNote == null)
            {
                return NotFound();
            }
            return Ok(taskNote);
        }

        // POST: api/TaskNotes
        [HttpPost]
        public async Task<ActionResult<TaskNote>> CreateTaskNote([FromBody] TaskNote taskNote)
        {
            if (taskNote == null)
            {
                return BadRequest();
            }

            var createdNote = await _taskNoteService.CreateTaskNoteAsync(taskNote);
            return CreatedAtAction(nameof(GetTaskNote), new { id = createdNote.NoteId }, createdNote);
        }

        // PUT: api/TaskNotes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskNote>> UpdateTaskNote(int id, [FromBody] TaskNote taskNote)
        {
            if (id != taskNote.NoteId)
            {
                return BadRequest();
            }

            var updatedNote = await _taskNoteService.UpdateTaskNoteAsync(taskNote);
            if (updatedNote == null)
            {
                return NotFound();
            }

            return Ok(updatedNote);
        }

        // DELETE: api/TaskNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskNote>> DeleteTaskNote(int id)
        {
            var taskNote = await _taskNoteService.DeleteTaskNoteAsync(id);
            if (taskNote == null)
            {
                return NotFound();
            }

            return Ok(taskNote);
        }
    }
}
