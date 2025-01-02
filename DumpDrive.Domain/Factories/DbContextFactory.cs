using Microsoft.EntityFrameworkCore;
using System.Configuration;
using DumpDrive.Data.Entities;

namespace DumpDrive.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DumpDriveDbContext GetDumpDriveDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql("Host=localhost;Database=DumpDrive;User Id=postgres;Password=tici0")
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
