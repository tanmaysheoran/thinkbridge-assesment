using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class TaskRequiredAction
    {
        [Key]
        public int ActionId { get; set; }
        public int TaskId { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public UserTask Task { get; set; }

        public ICollection<TaskDocument> Documents { get; set; }
    }
}
