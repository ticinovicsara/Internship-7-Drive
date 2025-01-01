using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;

namespace DumpDrive.Domain.Repositories
{
    public class SharedRepository : BaseRepository
    {
        public SharedRepository(DumpDriveDbContext dbcontext) : base(dbcontext)
        {
        }

        public IEnumerable<Folder> GetSharedFolders(int userId)
        {
            return DbContext.UserSharedFolders
            .Where(uf => uf.UserId == userId)
            .Select(uf => uf.Folder)
            .ToList();
        }

        public IEnumerable<DFile> GetSharedFiles(int userId)
        {
            return DbContext.UserSharedFiles
            .Where(uf => uf.UserId == userId)
            .Select(uf => uf.File)
            .ToList();
        }

        public IEnumerable<DFile> GetSharedFilesInFolder(int folderId, int userId)
        {
            return DbContext.UserSharedFiles
                .Where(uf => uf.UserId == userId && uf.File.FolderId == folderId)
                .Select(uf => uf.File)
                .ToList();
        }

        public ResponseResultType AddFolderShare(int folderId, int userId)
        {
            var user = DbContext.Users.FirstOrDefault(u => u.Id == userId);
            var folder = DbContext.Folders.FirstOrDefault(f => f.Id == folderId);

            if (user == null || folder == null)
                return ResponseResultType.NotFound;

            var existingEntry = DbContext.UserSharedFolders
                .FirstOrDefault(uf => uf.FolderId == folderId && uf.UserId == userId);

            if (existingEntry != null)
                return ResponseResultType.NoChanges;

            var shareEntry = new UserSharedFolder { FolderId = folderId, UserId = userId };
            DbContext.UserSharedFolders.Add(shareEntry);

            var filesInFolder = DbContext.Files.Where(f => f.FolderId == folderId).ToList();
            foreach (var file in filesInFolder)
            {
                var fileShareEntry = new UserSharedFile { FileId = file.Id, UserId = userId };
                DbContext.UserSharedFiles.Add(fileShareEntry);
            }

            return SaveChanges();
        }

        public ResponseResultType AddFileShare(int fileId, int userId)
        {
            var shareEntry = new UserSharedFile { FileId = fileId, UserId = userId };
            DbContext.UserSharedFiles.Add(shareEntry);

            return SaveChanges();
        }

        public ResponseResultType RemoveFolderShare(int folderId, int userId)
        {
            var share = DbContext.UserSharedFolders
                                .FirstOrDefault(fs => fs.FolderId == folderId && fs.UserId == userId);

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
                                 .FirstOrDefault(fs => fs.FileId == fileId && fs.UserId == userId);

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
