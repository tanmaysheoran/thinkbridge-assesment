namespace Management.Models
{
    public class TeamMember
    {
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public bool IsManager { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
