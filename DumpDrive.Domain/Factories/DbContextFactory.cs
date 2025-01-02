using Microsoft.EntityFrameworkCore;
using System.Configuration;
using DumpDrive.Data.Entities;

namespace DumpDrive.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DumpDriveDbContext GetDumpDriveDbContext()
        {
            var connectionString = Environment.GetEnvironmentVariable("DumpDrive");
            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
