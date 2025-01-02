namespace DumpDrive.Data.Entities.Models
{
    public class Files : Item
    {
        public Files(string name, string content) : base(name)
        {
            Content = content;
        }
        public Files(string name, string content, int? parentFolderId, int diskId) : base(name)
        {
            Content = content;
            ParentFolderId = parentFolderId;
            DriveId = diskId;
        }
        public string Content { get; set; }
    }
}
