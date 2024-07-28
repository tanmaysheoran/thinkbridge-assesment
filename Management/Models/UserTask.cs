using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; } = Status.New;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<TaskRequiredAction> RequiredActions { get; set; }
    }
}
