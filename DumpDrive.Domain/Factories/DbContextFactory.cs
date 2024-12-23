using DumpDrive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DumpDrive.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DumpDriveDbContext GetDumpDrivesDbContext(IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(configuration.GetConnectionString("DumpDrive"))
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
