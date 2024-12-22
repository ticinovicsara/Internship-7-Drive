using DumpDrive.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DumpDriveDbContext GetTodoAppDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["DumpDrive"].ConnectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }
    }
}
