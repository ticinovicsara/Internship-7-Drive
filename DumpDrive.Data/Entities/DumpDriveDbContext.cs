using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Data.Seeds;
using Microsoft.Extensions.Configuration;

namespace DumpDrive.Data.Entities
{
    public class DumpDriveDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<DFile> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<SharedFolder> UserSharedFolders { get; set; }
        public DbSet<SharedFile> UserSharedFiles { get; set; }

        public DumpDriveDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folder>()
                .HasOne(f => f.Owner)
                .WithMany(u => u.Folders)
                .HasForeignKey(f => f.OwnerId);

            modelBuilder.Entity<DFile>()
                .HasOne(f => f.Folder)
                .WithMany(f => f.Files)
                .HasForeignKey(f => f.FolderId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.File)
                .WithMany(f => f.Comments)
                .HasForeignKey(c => c.FileId);

            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.File)
                .WithMany(f => f.AuditLogs)
                .HasForeignKey(a => a.FileId);

            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.ChangedByUser)
                .WithMany(u => u.AuditLogs)
                .HasForeignKey(a => a.ChangedByUserId);

            modelBuilder.Entity<SharedFolder>()
                .HasKey(usf => new { usf.UserId, usf.FolderId });

            modelBuilder.Entity<SharedFolder>()
                .HasOne(usf => usf.User)
                .WithMany(u => u.SharedFolders)
                .HasForeignKey(usf => usf.UserId);

            modelBuilder.Entity<SharedFolder>()
                .HasOne(usf => usf.Folder)
                .WithMany(f => f.SharedUsers)
                .HasForeignKey(usf => usf.FolderId);

            modelBuilder.Entity<SharedFile>()
                .HasKey(usf => new { usf.UserId, usf.FileId });

            modelBuilder.Entity<SharedFile>()
                .HasOne(usf => usf.User)
                .WithMany(u => u.SharedFiles)
                .HasForeignKey(usf => usf.UserId);

            modelBuilder.Entity<UserSharedFile>()
                .HasOne(usf => usf.File)
                .WithMany(f => f.SharedUsers)
                .HasForeignKey(usf => usf.FileId);

            DbSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DumpDriveDbContextFactory : IDesignTimeDbContextFactory<DumpDriveDbContext>
    {
        public DumpDriveDbContext CreateDbContext(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var presentationLayerPath = Path.Combine(currentDirectory, "..", "DumpDrive.Presentation");

            if (!Directory.Exists(presentationLayerPath))
                throw new DirectoryNotFoundException($"Directory '{presentationLayerPath}' not found.");

            var configFilePath = Path.Combine(presentationLayerPath, "App.config.xml");

            if (!File.Exists(configFilePath))
                throw new FileNotFoundException($"Configuration file '{configFilePath}' not found.");

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
