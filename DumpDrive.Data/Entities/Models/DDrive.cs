namespace DumpDrive.Data.Entities.Models
{
    public class DDrive
    {
        public DDrive(string name)
        {
            Name = name;
        }

        public DDrive(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }

        public int DriveId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public List<Item> Items { get; set; } = new List<Item>();
    }
}