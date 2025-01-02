namespace Drive.Data.Entities.Models
{
    public class Folder : Item
    {
        public Folder(string name) : base(name)
        {

        }

        public Folder(string name, int? parentFolderId, int diskId) : base(name)
        {
            ParentFolderId = parentFolderId;
            DiskId = diskId;
        }

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
