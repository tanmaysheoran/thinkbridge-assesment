using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;
using System;

namespace Management.Services
{
    public class TaskAssignmentService : ITaskAssignmentService
    {
        private readonly ApplicationDbContext _context;

        public TaskAssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserTask>> GetTasksByUserIdAsync(int userId)
        {
            return _context.TaskAssignments
                .Where(ta => ta.UserId == userId)
                .Select(ta => ta.Task).ToList();        
                }

        public async Task<bool> CreateTaskAssigment(int userId, int taskId)
        {
            var taskAssignment = new TaskAssignment
            {
                UserId = userId,
                TaskId = taskId
            };

            _context.TaskAssignments.Add(taskAssignment);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTaskAssigment(int userId, int taskId)
        {
            var taskAssignment =  _context.TaskAssignments.FirstOrDefault(ta => ta.UserId == userId && ta.TaskId == taskId);

            if (taskAssignment == null)
            {
                return false;
            }

            _context.TaskAssignments.Remove(taskAssignment);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
