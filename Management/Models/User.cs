using System.ComponentModel.DataAnnotations;
using Management.Models;

namespace Management.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName {  get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<TaskAssignment> TaskAssignments { get; set; }
        public ICollection<TaskDocument> TaskDocuments { get; set; }

    }
}
