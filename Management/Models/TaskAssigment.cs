namespace Management.Models
{
    public class TaskAssignment
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        public UserTask Task { get; set; }
        public User User { get; set; }
    }
}
