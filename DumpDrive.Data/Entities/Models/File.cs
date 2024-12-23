using DumpDrive.Data.Enums;

namespace DumpDrive.Data.Entities.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public DateTime LastModified { get; set; }
        public Status Status { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public File(string name, int folderId, Status status)
        {
            Name = name;
            LastModified = DateTime.Now;
            FolderId = folderId;
            Status = status;
        }
    }

}
