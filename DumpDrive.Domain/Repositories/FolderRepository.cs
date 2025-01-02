using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;

namespace DumpDrive.Domain.Repositories
{
    public class FolderRepository : BaseRepository
    {
        public FolderRepository(DumpDriveDbContext DbContext) : base(DbContext)
        {
        }

        public ResponseResultType Add(Folder folder)
        {
            DbContext.Folders.Add(folder);

            return SaveChanges();
        }

        public ResponseResultType Update(Folder folder, int folderId) 
        {
            var folderToUpdate = DbContext.Folders.Find(folderId);

            if (folderToUpdate == null)
                return ResponseResultType.NotFound;

            folderToUpdate.Name = folder.Name;

            return SaveChanges();
        }
        public Folder? GetByName(string folderName, User user) => DbContext.Folders.FirstOrDefault(f => f.Name == folderName && user.DriveId == f.DriveId);
    }
}

