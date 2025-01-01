using DumpDrive.Data.Enums;

namespace DumpDrive.Data.Entities.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int? ParentFolderId {  get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User Owner { get; set; }
        public ICollection<Folder> SubFolders { get; set; } = new List<Folder>();
        public ICollection<DFile> Files { get; set; } = new List<DFile>();

        int counter = 0;
        public Folder(string name, int ownerId)
        {
            Id = counter++;
            Name = name;
            OwnerId = ownerId;
            Status = Status.Private;
        }
    }
}
