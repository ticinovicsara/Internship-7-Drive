using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Data.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User(string name, string surname) {
            Name = name;
            Surname = surname;
        }

        public ICollection<Folder> Folders { get; set; } = new List<Folder>();
        public ICollection<File> Files { get; set; } = new List<File>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
