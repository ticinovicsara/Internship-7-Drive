using DumpDrive.Data.Entities.Models;
using DumpDrive.Data.Entities;
using DumpDrive.Data.Enums;
using DumpDrive.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DumpDrive.Domain.Repositories
{
    public class DriveRepository : BaseRepository
    {
        public DriveRepository(DumpDriveDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<DFile> GetUserFiles(int userId)
        {
            return DbContext.Files
                .Where(f => f.Folder.OwnerId == userId)
                .Select(f => new DFile(f.Name, f.FolderId, f.OwnerId)
                {
                    Id = f.Id,
                    LastModified = f.LastModified,
                    Status = f.Status
                })
                .OrderByDescending(f => f.LastModified)
                .ToList();
        }



        public ICollection<DFile> GetFolderFiles(int folderId)
        {
            return DbContext.Files
                .Where(f => f.FolderId == folderId)
                .Select(f => new DFile(f.Name, f.FolderId, f.OwnerId)
                {
                    Id = f.Id,
                    LastModified = f.LastModified,
                    Status = f.Status
                })
                .OrderByDescending(f => f.LastModified)
                .ToList();
        }

        public Folder GetFolderByName(int userId, string folderName)
        {
            return DbContext.Folders
                .Where(f => f.OwnerId == userId && f.Name.ToLower() == folderName.ToLower())
                .FirstOrDefault();
        }

        public DFile GetFileByName(int userId, string fileName)
        {
            return DbContext.Files
                .Where(f => f.Folder.OwnerId == userId && f.Name.ToLower() == fileName.ToLower())
                .FirstOrDefault();
        }

        public ResponseResultType CreateFolder(int userId, string folderName)
        {
            var isDuplicate = DbContext.Folders.Any(f => f.OwnerId == userId && f.Name == folderName);
            if (isDuplicate) return ResponseResultType.Conflict;

            var folder = new Folder(folderName, userId);
            DbContext.Folders.Add(folder);

            return SaveChanges();
        }

        public ResponseResultType CreateFile(int folderId, string fileName, int ownerId)
        {
            var folderExists = DbContext.Folders.Any(f => f.Id == folderId);
            if (!folderExists) return ResponseResultType.NotFound;

            var isDuplicate = DbContext.Files.Any(f => f.FolderId == folderId && f.Name.ToLower() == fileName.ToLower());
            if (isDuplicate) return ResponseResultType.Conflict;

            var file = new DFile(fileName, folderId, ownerId)
            {
                Status = Status.Private
            };
            DbContext.Files.Add(file);

            return SaveChanges();
        }

        public ResponseResultType UpdateFileContent(int fileId, string newContent)
        {
            var file = DbContext.Files.FirstOrDefault(f => f.Id == fileId);
            if (file == null)
            {
                return ResponseResultType.NotFound;
            }

            file.Content = newContent;
            file.LastModified = DateTime.UtcNow;

            DbContext.SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType DeleteFolder(int userId, string folderName)
        {
            var folder = DbContext.Folders.FirstOrDefault(f => f.OwnerId == userId && f.Name.ToLower() == folderName.ToLower());

            if (folder == null)
                return ResponseResultType.NotFound;

            DbContext.Folders.Remove(folder);
            DbContext.SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType DeleteFile(int userId, string fileName)
        {
            var file = DbContext.Files
                .FirstOrDefault(f => f.Folder.OwnerId == userId &&
                                     f.Name.ToLower() == fileName.ToLower());

            if (file == null)
                return ResponseResultType.NotFound;

            DbContext.Files.Remove(file);
            DbContext.SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType RenameFolder(int userId, string oldName, string newName)
        {
            var folder = DbContext.Folders
                .FirstOrDefault(f => f.OwnerId == userId && f.Name.ToLower() == oldName.ToLower());

            if (folder == null)
                return ResponseResultType.NotFound;

            folder.Name = newName;
            DbContext.SaveChanges();
            return ResponseResultType.Success;
        }

        public ResponseResultType RenameFile(int userId, string oldName, string newName)
        {
            var file = DbContext.Files.FirstOrDefault(f => f.Folder.OwnerId == userId && f.Name.ToLower() == oldName.ToLower());

            if (file == null)
                return ResponseResultType.NotFound;

            file.Name = newName;
            DbContext.SaveChanges();
            return ResponseResultType.Success;
        }
    }
}
