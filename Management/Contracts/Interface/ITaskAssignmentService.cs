using Management.Models;

namespace Management.Contracts.Interface
{
    public interface ITaskAssignmentService
    {
        Task<List<UserTask>> GetTasksByUserIdAsync(int userId);
        Task<bool> CreateTaskAssigment(int userId, int taskId);
        Task<bool> DeleteTaskAssigment(int userId, int taskId);
    }
}
