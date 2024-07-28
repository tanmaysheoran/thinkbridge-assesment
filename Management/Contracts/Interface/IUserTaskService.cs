using Management.Models;

namespace Management.Contracts.Interface
{
    public interface IUserTaskService
    {
        Task<UserTask> GetUserTaskAsync(int id);
        Task<List<UserTask>> GetUserTaskListByTeamAsync(int teamId);
        Task<UserTask> CreateUserTask(string title, string description, int teamId, DateTime dueDatem, Priority priority);
        Task<UserTask> UpdateUserTaskAsync(UserTask userTask);
        Task<UserTask> DeleteUserTaskAsync(int id);
    }
}
