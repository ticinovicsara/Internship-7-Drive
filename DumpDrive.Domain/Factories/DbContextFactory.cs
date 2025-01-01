using DumpDrive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DumpDrive.Domain.Factories
{
    public class DumpDriveDbContextFactory : IDesignTimeDbContextFactory<DumpDriveDbContext>
    {
        public DumpDriveDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DumpDriveDbContext>();

            var connectionString = "Host=localhost;Port=5432;Database=DumpDrive;Username=postgres;Password=tici0";

            optionsBuilder.UseNpgsql(connectionString);

            return new DumpDriveDbContext(optionsBuilder.Options);
        }
    }

}
