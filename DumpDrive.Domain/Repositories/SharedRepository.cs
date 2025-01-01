using DumpDrive.Data.Entities;
using DumpDrive.Data.Enums;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;

namespace DumpDrive.Domain.Repositories
{
    public class SharedRepository : BaseRepository
    {
        public SharedRepository(DumpDriveDbContext dbcontext) : base(dbcontext)
        {
        }

        public IEnumerable<SharedItem> GetSharedFolders(int userId)
        {
            return DbContext.UserSharedFolders
                .Where(si => si.SharedWithUserId == userId && si.Itemtype == ItemType.Folder)
                .ToList();
        }

        public IEnumerable<SharedItem> GetSharedFiles(int userId)
        {
            return DbContext.UserSharedFiles
                .Where(si => si.SharedWithUserId == userId && si.Itemtype == ItemType.File)
                .ToList();
        }

        public IEnumerable<DFile> GetSharedFilesInFolder(int folderId, int userId)
        {
            var sharedFiles = DbContext.UserSharedFiles
                .Where(si => si.SharedWithUserId == userId && si.Itemtype == ItemType.File)
                .ToList();

            var filesInFolder = sharedFiles
                .Where(si => si.ItemId == folderId)
                .Select(si => DbContext.Files.FirstOrDefault(f => f.Id == si.ItemId))
                .Where(f => f != null)
                .ToList();

            return filesInFolder;
        }

        public ResponseResultType AddFolderShare(int folderId, int userId)
        {
            var user = DbContext.Users.FirstOrDefault(u => u.Id == userId);
            var folder = DbContext.Folders.FirstOrDefault(f => f.Id == folderId);
            if (folder == null || user == null)
                return ResponseResultType.NotFound;

            var existingFolderShare = DbContext.UserSharedFolders
                .FirstOrDefault(si => si.ItemId == folderId && si.SharedWithUserId == userId && si.Itemtype == ItemType.Folder);

            if (existingFolderShare != null)
                return ResponseResultType.NoChanges;

            var folderShareEntry = new SharedItem(folder.Name, ItemType.Folder)
            {
                ItemId = folderId,
                SharedWithUserId = userId,
                OwnerId = folder.OwnerId
            };
            DbContext.UserSharedFolders.Add(folderShareEntry);

            var filesInFolder = DbContext.Files.Where(f => f.FolderId == folderId).ToList();

            foreach (var file in filesInFolder)
            {
                var existingFileShare = DbContext.UserSharedFiles
                    .FirstOrDefault(si => si.ItemId == file.Id && si.SharedWithUserId == userId && si.Itemtype == ItemType.File);

                if (existingFileShare == null)
                {
                    var fileShareEntry = new SharedItem(file.Name, ItemType.File)
                    {
                        ItemId = file.Id,
                        SharedWithUserId = userId,
                        OwnerId = file.OwnerId
                    };
                    DbContext.UserSharedFiles.Add(fileShareEntry);
                }
            }

            return SaveChanges();
        }


        public ResponseResultType AddFileShare(int fileId, int userId)
        {
            var existingShare = DbContext.UserSharedFiles
                .FirstOrDefault(si => si.ItemId == fileId && si.SharedWithUserId == userId);

            if (existingShare != null)
                return ResponseResultType.NoChanges;

            var file = DbContext.Files.FirstOrDefault(f => f.Id == fileId);
            if (file == null)
                return ResponseResultType.NotFound;

            var shareEntry = new SharedItem(file.Name, ItemType.File)
            {
                ItemId = fileId,
                SharedWithUserId = userId,
                OwnerId = file.OwnerId
            };

            DbContext.UserSharedFiles.Add(shareEntry);
            return SaveChanges();
        }

        public ResponseResultType RemoveFolderShare(int folderId, int userId)
        {
            var share = DbContext.UserSharedFolders
                .FirstOrDefault(si => si.ItemId == folderId && si.SharedWithUserId == userId);

            if (share != null)
            {
                DbContext.UserSharedFolders.Remove(share);
                DbContext.SaveChanges();
                return ResponseResultType.Success;
            }

            return ResponseResultType.NotFound;
        }


        public ResponseResultType RemoveFileShare(int fileId, int userId)
        {
            var share = DbContext.UserSharedFiles
                .FirstOrDefault(si => si.ItemId == fileId && si.SharedWithUserId == userId);

            if (share != null)
            {
                DbContext.UserSharedFiles.Remove(share);
                DbContext.SaveChanges();
                return ResponseResultType.Success;
            }

            return ResponseResultType.NotFound;
        }


        public IEnumerable<Comment> GetComments(int fileId)
        {
            return DbContext.Comments
                .Where(c => c.FileId == fileId)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
        }

        public ResponseResultType AddComment(int fileId, int userId, string content)
        {
            var file = DbContext.Files.FirstOrDefault(f => f.Id == fileId);

            if (file == null)
                return ResponseResultType.NotFound;

            var comment = new Comment(content, fileId, userId);
            DbContext.Comments.Add(comment);
            DbContext.SaveChanges();

            return ResponseResultType.Success;
        }
    }
}
