using DumpDrive.Data.Enums;
using System;

namespace DumpDrive.Data.Entities.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public ChangeType ChangeType { get; set; }
        public int FileId { get; set; }
        public DumpFile? File { get; set; }
        public int ChangedByUserId { get; set; }
        public User? ChangedByUser { get; set; }
        public DateTime Timestamp { get; set; }

        public AuditLog(ChangeType changeType, int fileId, int changedByUserId)
        {
            ChangeType = changeType;
            FileId = fileId;
            ChangedByUserId = changedByUserId;
            Timestamp = DateTime.UtcNow;
        }
    }
}
