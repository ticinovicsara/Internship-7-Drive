namespace DumpDrive.Data.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int FileId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }

        int counter = 0;
        public Comment(string content, int fileId, int userId)
        {
            Id = counter++;
            Content = content;
            FileId = fileId;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }
    }
}
