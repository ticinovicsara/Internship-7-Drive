using DumpDrive.Data.Enums;

namespace DumpDrive.Data.Entities.Models
{
    public class DFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Content { get; set; }
        public int OwnerId { get; set; }
        public User? Owner { get; set; }
        public int FolderId { get; set; }
        public Folder? Folder { get; set; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public Status Status { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<SharedFile> SharedUsers { get; set; } = new List<SharedFile>();
        public ICollection<AuditLog>? AuditLogs { get; set; } = new List<AuditLog>();

        public DFile(string name, int folderId, int ownerId)
        {
            Name = name;
            FolderId = folderId;
            Status = Status.Private;
            OwnerId = ownerId;
        }
    }

}
