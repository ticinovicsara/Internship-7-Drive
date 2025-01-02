namespace Drive.Data.Entities.Models
{
    public class Disk
    {
        public Disk(string name)
        {
            Name = name;
        }

        public Disk(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }

        public int DiskId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public List<Item> Items { get; set; } = new List<Item>();
    }
}