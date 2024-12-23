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
        public ICollection<File> Files { get; set; } = new List<File>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
