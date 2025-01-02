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
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
        public ICollection<SharedFolder> SharedFolders { get; set; } = new List<SharedFolder>();
        public ICollection<SharedFile> SharedFiles { get; set; } = new List<SharedFile>();
    }
}
