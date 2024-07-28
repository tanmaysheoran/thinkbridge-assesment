using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<UserTask> Tasks { get; set; }
    }
}
