using DumpDrive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DumpDrive.Domain.Factories
{
    public class DbContextFactory
    {

        public static DumpDriveDbContext GetDumpDriveDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DumpDrive");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DumpDrive' not found.");
            }

            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
