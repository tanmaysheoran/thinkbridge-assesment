using Management.Contracts.Interface;
using Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmunController : ControllerBase
    {
        private readonly IEmunService _emunService;

        public EmunController(IEmunService emunService)
        {
            _emunService = emunService;
        }

        [HttpGet("priorities")]
        public ActionResult<List<string>> GetPriorities()
        {
            var priorities = _emunService.GetPriorityItems();
            return Ok(priorities);
        }

        [HttpGet("statuses")]
        public ActionResult<List<string>> GetStatuses()
        {
            var statuses = _emunService.GetStatusItems();
            return Ok(statuses);
        }

        [HttpGet("action-types")]
        public ActionResult<List<string>> GetActionTypes()
        {
            var actionTypes = _emunService.GetActionTypeItems();
            return Ok(actionTypes);
        }
    }
}
