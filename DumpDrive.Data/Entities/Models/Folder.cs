using DumpDrive.Data.Enums;

namespace DumpDrive.Data.Entities.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public User? Owner { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Folder> SubFolders { get; set; } = new List<Folder>();
        public ICollection<DFile> Files { get; set; } = new List<DFile>();
        public ICollection<SharedFolder> SharedUsers { get; set; } = new List<SharedFolder>();

        public Folder(string name, int ownerId)
        {
            Name = name;
            OwnerId = ownerId;
            Status = Status.Private;
        }
    }
}
