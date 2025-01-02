using DumpDrive.Data.Entities;
using DumpDrive.Domain.Enums;
using DumpDrive.Data.Entities.Models;

namespace DumpDrive.Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DumpDriveDbContext DbContext) : base(DbContext)
        {
        }

        public ResponseResultType Add(Files file)
        {
            DbContext.Files.Add(file);

            return SaveChanges();
        }

        public ResponseResultType Update(Files file, int fileId)
        {
            var fileToUpdate = DbContext.Files.Find(fileId);

            if (fileToUpdate == null)
                return ResponseResultType.NotFound;

            fileToUpdate.Name = file.Name;
            fileToUpdate.Content = file.Content;
            fileToUpdate.LastChangedAt = DateTime.UtcNow;

            return SaveChanges();
        }

        public Files? GetById(int fileId) => DbContext.Files.FirstOrDefault(f => f.ItemId == fileId);
        public Files? GetByName(string fileName, User user) => DbContext.Files.FirstOrDefault(f => f.Name == fileName && user.DriveId == f.DriveId);
    }
}
