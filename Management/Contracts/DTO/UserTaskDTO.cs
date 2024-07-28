using Management.Models;

namespace Management.Contracts.DTO
{
    public class CreateUserTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
    }
}
