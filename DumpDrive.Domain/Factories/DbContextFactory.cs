using Microsoft.EntityFrameworkCore;
using System.Configuration
using DummpDrive.Data.Entities;

namespace DumpDrive.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DumpDriveDbContext GetDriveDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["DumpDrive"].ConnectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
