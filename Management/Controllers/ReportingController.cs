using Management.Contracts.Interface;
using Management.Models;
using Microsoft.AspNetCore.Mvc;


namespace Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportingController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public ReportingController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [HttpGet("TaskStatusCounts")]
        public ActionResult<List<TaskStatusCount>> GetTaskStatusCounts([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = _reportingService.GetTaskStatusCounts(startDate, endDate);
            return Ok(result);
        }
    }

}
