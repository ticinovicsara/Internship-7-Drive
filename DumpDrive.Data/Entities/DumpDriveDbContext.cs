using Microsoft.EntityFrameworkCore;
using DumpDrive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore.Design;
using DumpDrive.Data.Seeds;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.PendingModelChangesWarning))
                .LogTo(Console.WriteLine);
        }
    }


    public class DumpDriveDbContextFactory : IDesignTimeDbContextFactory<DumpDriveDbContext>
    {
        public DumpDriveDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddXmlFile("App.config");

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DumpDrive");

            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
