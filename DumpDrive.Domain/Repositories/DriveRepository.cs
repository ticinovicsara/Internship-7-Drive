using DumpDrive.Data.Entities;
using DumpDrive.Domain.Enums;
using DumpDrive.Data.Entities.Models;

namespace DumpDrive.Domain.Repositories
{
    public class DriveRepository : BaseRepository
    {
        public DriveRepository(DumpDriveDbContext DbContext) : base(DbContext)
        {
        }
        public ResponseResultType Add(DDrive disk)
        {
            DbContext.Drives.Add(disk);

            return SaveChanges();
        }
        public DDrive? GetById(int diskId) => DbContext.Drives.FirstOrDefault(d => d.DriveId == diskId);
    }
}
