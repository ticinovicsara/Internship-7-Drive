using Microsoft.EntityFrameworkCore;
using DumpDrive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore.Design;
using DumpDrive.Data.Seeds;
using System.Xml.Linq;

namespace DumpDrive.Data.Entities
{
    public class DumpDriveDbContext : DbContext
    {
        public DumpDriveDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<DFile> Files { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SharedItem> SharedItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>()
                .HasOne(f => f.Owner)
                .WithMany(u => u.Folders)
                .HasForeignKey(f => f.OwnerId);

            modelBuilder.Entity<Folder>()
                .HasMany(f => f.SubFolders)
                .WithOne()
                .HasForeignKey(f => f.ParentFolderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DFile>()
                .HasOne(f => f.Owner)
                .WithMany(u => u.Files)
                .HasForeignKey(f => f.OwnerId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<SharedItem>()
                .HasOne(s => s.SharedWithUser)
                .WithMany()
                .HasForeignKey(s => s.SharedWithUserId)
                .OnDelete(DeleteBehavior.Restrict);

            DbSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }


    public class DumpDriveDbContextFactory : IDesignTimeDbContextFactory<DumpDriveDbContext>
    {
        public DumpDriveDbContext CreateDbContext(string[] args)
        {
            var presentationLayerPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\DumpDrive.Presentation");
            var configFilePath = Path.Combine(presentationLayerPath, "App.config");

            var configXml = XElement.Load(configFilePath);

            var connectionString = configXml
                .Element("connectionStrings")?
                .Elements("add")
                .FirstOrDefault(e => e.Attribute("name")?.Value == "DumpDrive")?
                .Attribute("connectionString")?.Value;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DumpDrive' not found in app.config.");
            }

            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
