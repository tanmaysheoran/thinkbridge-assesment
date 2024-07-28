using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly ApplicationDbContext _context;

        public UserTaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserTask> GetUserTaskAsync(int id)
        {
            return await _context.Set<UserTask>().FindAsync(id);
        }

        public async Task<List<UserTask>> GetUserTaskListByTeamAsync(int teamId)
        {
            return await _context.Set<UserTask>().Where(ut => ut.TeamId == teamId).ToListAsync();
        }

        public async Task<UserTask> CreateUserTask(string title, string description, int teamId, DateTime dueDate, Priority priority)
        {
            var userTask = new UserTask
            {
                Title = title,
                Description = description,
                TeamId = teamId,
                DueDate = dueDate,
                Priority = priority,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Set<UserTask>().Add(userTask);
            await _context.SaveChangesAsync();

            return userTask;
        }

        public async Task<UserTask> UpdateUserTaskAsync(UserTask userTask)
        {
            _context.Set<UserTask>().Update(userTask);
            await _context.SaveChangesAsync();

            return userTask;
        }

        public async Task<UserTask> DeleteUserTaskAsync(int id)
        {
            var userTask = await _context.Set<UserTask>().FindAsync(id);
            if (userTask == null)
            {
                return null;
            }

            _context.Set<UserTask>().Remove(userTask);
            await _context.SaveChangesAsync();

            return userTask;
        }
    }
}
