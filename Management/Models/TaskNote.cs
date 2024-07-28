using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class TaskNote
    {
        [Key]
        public int NoteId { get; set; }
        public int ActionId { get; set; }
        public string NoteText { get; set; }
        public DateTime CreatedAt { get; set; }
        public TaskRequiredAction RequiredAction { get; set; }
    }
}
