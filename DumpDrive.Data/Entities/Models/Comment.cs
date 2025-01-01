namespace DumpDrive.Data.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int FileId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DFile? File { get; set; }

        public Comment(string content, int fileId, int userId)
        {
            Content = content;
            FileId = fileId;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
