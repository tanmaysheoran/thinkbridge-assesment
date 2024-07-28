using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;

namespace Management.Services
{

    public class TaskRequiredActionService : ITaskRequiredAction
    {
        private readonly ApplicationDbContext _context;

        public TaskRequiredActionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskRequiredAction>> GetRequiredActionsByTaskIdAsync(int taskId)
        {
            return  _context.TaskRequiredActions
                                 .Where(ra => ra.TaskId == taskId).ToList();
        }

        public async Task<TaskRequiredAction> GetRequiredActionAsync(int id)
        {
            return  _context.TaskRequiredActions
                                 .FirstOrDefault(ra => ra.ActionId == id);
        }

        public async Task<TaskRequiredAction> CreateRequiredAction(int taskId, ActionType actionType, DateTime dueDate, Status status)
        {
            var requiredAction = new TaskRequiredAction
            {
                TaskId = taskId,
                ActionType = actionType,
                DueDate = dueDate,
                Status = status,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.TaskRequiredActions.Add(requiredAction);
            await _context.SaveChangesAsync();

            return requiredAction;
        }

        public async Task<TaskRequiredAction> UpdateRequiredActionAsync(TaskRequiredAction action)
        {
            var existingAction = _context.TaskRequiredActions
                                               .FirstOrDefault(ra => ra.ActionId == action.ActionId);

            if (existingAction == null)
            {
                return null;
            }

            existingAction.ActionType = action.ActionType;
            existingAction.DueDate = action.DueDate;
            existingAction.Status = action.Status;
            existingAction.UpdatedAt = DateTime.UtcNow;

            _context.TaskRequiredActions.Update(existingAction);
            await _context.SaveChangesAsync();

            return existingAction;
        }

        public async Task<TaskRequiredAction> DeleteRequiredActionAsync(int id)
        {
            var action = _context.TaskRequiredActions
                                       .FirstOrDefault(ra => ra.ActionId == id);

            if (action == null)
            {
                return null;
            }

            _context.TaskRequiredActions.Remove(action);
            await _context.SaveChangesAsync();

            return action;
        }
    }
}
