using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;

namespace Management.Services
{
    public class ReportingService : IReportingService
    {
        private readonly ApplicationDbContext _context;

        public ReportingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TaskStatusCount> GetTaskStatusCounts(DateTime startDate, DateTime endDate)
        {
            var query = from task in _context.Tasks
                        where task.DueDate >= startDate && task.DueDate <= endDate
                        group task by task.Status into taskGroup
                        select new TaskStatusCount
                        {
                            Status = taskGroup.Key,
                            Count = taskGroup.Count()
                        };

            return query.ToList();
        }
    }

}
