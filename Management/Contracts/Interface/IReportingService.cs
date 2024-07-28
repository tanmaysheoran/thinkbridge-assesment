using Management.Models;
namespace Management.Contracts.Interface
{
    public interface IReportingService
    {
        List<TaskStatusCount> GetTaskStatusCounts(DateTime startDate, DateTime endDate);
    }

}
