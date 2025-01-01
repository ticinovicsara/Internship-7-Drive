namespace DumpDrive.Data.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string email, string password, string name, string surname) {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }

        public ICollection<Folder> Folders { get; set; } = new List<Folder>();
        public ICollection<DFile> Files { get; set; } = new List<DFile>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<AuditLog>? AuditLogs { get; set; }
        public ICollection<SharedItem> OwnedSharedItems { get; set; } = new List<SharedItem>();
        public ICollection<SharedItem> SharedWithItems { get; set; } = new List<SharedItem>();
    }
}
