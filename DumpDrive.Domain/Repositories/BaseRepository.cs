using DumpDrive.Data.Entities;
using DumpDrive.Domain.Enums;

namespace DumpDrive.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly DumpDriveDbContext DbContext;

        protected BaseRepository(DumpDriveDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ResponseResultType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ResponseResultType.Success;

            return ResponseResultType.NoChanges;
        }
    }
}
