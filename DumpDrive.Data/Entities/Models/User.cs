namespace DumpDrive.Data.Entities.Models
{
    public class User
    {
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int DriveId { get; set; }
        public DDrive Drive { get; set; } = null!;

        public List<SharedItem> SharedItems { get; set; } = new List<SharedItem>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}