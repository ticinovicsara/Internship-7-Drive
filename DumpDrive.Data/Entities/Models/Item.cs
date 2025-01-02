namespace DumpDrive.Data.Entities.Models
{
    public abstract class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastChangedAt { get; set; }

        public int DriveId { get; set; }
        public DDrive? Drive { get; set; }

        public int? ParentFolderId { get; set; }
        public Folder? ParentFolder { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}