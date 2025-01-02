using DumpDrive.Data.Seeds;
using DumpDrive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace DumpDrive.Data.Entities
{
    public class DumpDriveDbContext : DbContext
    {
        public DumpDriveDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<DDrive> Drives => Set<DDrive>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Folder> Folders => Set<Folder>();
        public DbSet<Files> Files => Set<Files>();
        public DbSet<SharedItem> SharedItems => Set<SharedItem>();
        public DbSet<Comment> Comments => Set<Comment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
               .HasDiscriminator<string>("Item_type")
               .HasValue<Folder>("Folder")
               .HasValue<Files>("File");

            modelBuilder.Entity<Item>()
               .HasOne<Folder>()
               .WithMany(f => f.Items)
               .HasForeignKey(i => i.ParentFolderId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Drive)
                .WithOne(d => d.User)
                .HasForeignKey<DDrive>(d => d.UserId);

            modelBuilder.Entity<DDrive>()
                .HasMany(d => d.Items)
                .WithOne(i => i.Drive)
                .HasForeignKey(i => i.DriveId);

            modelBuilder.Entity<SharedItem>()
                .HasOne(s => s.Item)
                .WithMany()
                .HasForeignKey(s => s.ItemId);

            modelBuilder.Entity<SharedItem>()
                .HasOne(s => s.User)
                .WithMany(u => u.SharedItems)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Item)
                .WithMany(i => i.Comments)
                .HasForeignKey(c => c.ItemId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            DbSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                   warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }

    public class DriveDbContextFactory : IDesignTimeDbContextFactory<DumpDriveDbContext>
    {
        public DumpDriveDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("App.config")
                .Build();

            config.Providers
                .First()
                .TryGet("connectionStrings:add:Drive:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}