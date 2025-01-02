using DumpDrive.Data.Seeds;
using DumpDrive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DumpDrive.Data.Entities
{
    public class DumpDriveDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DumpDriveDbContext(DbContextOptions options) : base(options)
        {
        }

        public DumpDriveDbContext(DbContextOptions<DumpDriveDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users {  get; set; }
        public DbSet<DDrive> Drives { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<SharedItem> SharedItems { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DumpDrive");
                optionsBuilder.UseNpgsql(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

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
                .HasKey(d => d.DriveId);

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
    }

    public class DriveDbContextFactory : IDesignTimeDbContextFactory<DumpDriveDbContext>
    {
        public DumpDriveDbContext CreateDbContext(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var presentationLayerPath = Path.Combine(currentDirectory, "..", "DumpDrive.Presentation");

            if (!Directory.Exists(presentationLayerPath))
                throw new DirectoryNotFoundException($"Directory '{presentationLayerPath}' not found.");

            var configFilePath = Path.Combine(presentationLayerPath, "appsettings.json");

            if (!File.Exists(configFilePath))
                throw new FileNotFoundException($"Configuration file '{configFilePath}' not found.");

            var config = new ConfigurationBuilder()
                .SetBasePath(presentationLayerPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DumpDrive");

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'DumpDrive' not found or is empty.");

            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}