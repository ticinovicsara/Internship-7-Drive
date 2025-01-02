using DummpDrive.Data.Entities.Models;

namespace DumpDrive.Data.Entities.Models
{
    public class SharedItem
    {
        public SharedItem(int itemId, int userId, string itemName)
        {
            ItemId = itemId;
            UserId = userId;
            ItemName = itemName;
        }
        public int SharedItemId { get; set; }

        public int ItemId { get; set; }
        public Item? Item { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        public string ItemName { get; set; }
    }
}