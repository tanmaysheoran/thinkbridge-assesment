using Management.Models;

namespace Management.Contracts.DTO
{
    public class CreateRequiredActionRequest
    {
        public int TaskId { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
    }
}
