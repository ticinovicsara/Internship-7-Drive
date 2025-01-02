namespace DumpDrive.Data.Entities.Models
{
    public class Folder : Item
    {
        public Folder(string name) : base(name)
        {

        }

        public Folder(string name, int? parentFolderId, int diskId) : base(name)
        {
            ParentFolderId = parentFolderId;
            DriveId = diskId;
        }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
