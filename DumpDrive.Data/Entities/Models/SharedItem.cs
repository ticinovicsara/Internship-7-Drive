using DumpDrive.Data.Enums;

namespace DumpDrive.Data.Entities.Models
{
    public class SharedItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public ItemType? Itemtype { get; set; }
        public int? SharedWithUserId { get; set; }
        public int OwnerId { get; set; }

        public SharedItem(string name, ItemType itemtype)
        {
            Itemtype = itemtype;
            Name = name;
        }

        public User? SharedWithUser { get; set; }
        public User? Owner { get; set; }
    }
}
