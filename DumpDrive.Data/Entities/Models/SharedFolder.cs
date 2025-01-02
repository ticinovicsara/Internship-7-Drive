namespace DumpDrive.Data.Entities.Models
{
    public class SharedFolder
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
    }
}
