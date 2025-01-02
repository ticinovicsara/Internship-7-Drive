namespace DumpDrive.Data.Entities.Models
{
    public class SharedFile
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int FileId { get; set; }
        public DFile File { get; set; }
    }
}
