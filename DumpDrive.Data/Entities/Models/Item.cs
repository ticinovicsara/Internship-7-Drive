namespace Drive.Data.Entities.Models
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

        public int DiskId { get; set; }
        public Disk? Disk { get; set; }

        public int? ParentFolderId { get; set; }
        public Folder? ParentFolder { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}