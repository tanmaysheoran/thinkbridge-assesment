using Management.Models;

namespace Management.Contracts.Interface
{
    public interface ITaskNoteSerivce
    {
        Task<TaskNote> GetTaskNoteAsync(int id);
        Task<TaskNote> GetTaskNoteByActionIdAsync(int actionId);
        Task<TaskNote> CreateTaskNoteAsync(TaskNote note);
        Task<TaskNote> UpdateTaskNoteAsync(TaskNote note);
        Task<TaskNote> DeleteTaskNoteAsync(int id);
    }
}
