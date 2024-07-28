namespace Management.Models
{
    public class TaskDocument
    {
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }

        public int ActionId { get; set; }
        public TaskRequiredAction Action { get; set; }

        public int UploadedBy { get; set; }
        public User UploadedByUser { get; set; }
    }
}
