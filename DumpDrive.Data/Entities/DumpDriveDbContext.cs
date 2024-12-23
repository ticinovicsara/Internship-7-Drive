using Microsoft.EntityFrameworkCore;
using DumpDrive.Data.Entities.Models;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Design;

namespace DumpDrive.Data.Entities
{
    public class DumpDriveDbContext : DbContext
    {
        public DumpDriveDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }
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

            modelBuilder.Entity<File>()
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
            var configFilePath = Path.Combine(presentationLayerPath, "App.config.xml");

            var config = new ConfigurationBuilder()
                .SetBasePath(presentationLayerPath)
                .AddXmlFile(configFilePath)
                .Build();

            config.Providers
                .First()
                .TryGet("connectionStrings:add:DumpDrive:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
