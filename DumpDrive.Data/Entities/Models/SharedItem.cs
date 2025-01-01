namespace DumpDrive.Data.Entities.Models
{
    public class SharedItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? Itemtype { get; set; }
        public int? SharedWithUserId { get; set; }
        public int OwnerId { get; set; }

        public SharedItem(string name, string itemtype)
        {
            Itemtype = itemtype;
            Name = name;
        }

        public SharedItem() { }

        public User? SharedWithUser { get; set; }
        public User? Owner { get; set; }
    }
}
