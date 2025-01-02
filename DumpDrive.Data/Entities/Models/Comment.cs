using DummpDrive.Data.Entities.Models;

namespace DumpDrive.Data.Entities.Models
{
    public class Comment
    {
        public Comment(string content)
        {
            Content = content;
        }

        public Comment(string content, int userId, int itemId)
        {
            Content = content;
            UserId = userId;
            ItemId = itemId;
        }

        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int ItemId { get; set; }
        public Item? Item { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}