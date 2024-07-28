using Management.Models;

namespace Management.Contracts.Interface
{
    public interface ITaskRequiredAction
    {
        Task<List<TaskRequiredAction>> GetRequiredActionsByTaskIdAsync(int taskId);
        Task<TaskRequiredAction> GetRequiredActionAsync(int id);
        Task<TaskRequiredAction> CreateRequiredAction(int taskId, ActionType actionType, DateTime dueDate, Status status);
        Task<TaskRequiredAction> UpdateRequiredActionAsync(TaskRequiredAction action);
        Task<TaskRequiredAction> DeleteRequiredActionAsync(int id);
    }
}
