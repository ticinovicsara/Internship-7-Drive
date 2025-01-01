using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DumpDrive.Domain.Repositories
{
    public class FileRepository
    {
        private readonly DumpDriveDbContext _dbContext;

        public FileRepository(DumpDriveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<DFile> GetFilesByUser(int userId)
        {
            return _dbContext.Files.Where(f => f.OwnerId == userId).ToList();
        }

        public ICollection<DFile> GetSharedFilesByUser(int userId)
        {
            return _dbContext.Files.Where(f => f.OwnerId == userId && f.Status == Data.Enums.Status.Shared).ToList();
        }

        public void AddFile(DFile file)
        {
            _dbContext.Files.Add(file);
            _dbContext.SaveChanges();
        }

        public void DeleteFile(int fileId)
        {
            var file = _dbContext.Files.FirstOrDefault(f => f.Id == fileId);
            if (file != null)
            {
                _dbContext.Files.Remove(file);
                _dbContext.SaveChanges();
            }
        }

        public void ShareFileWithUser(int fileId, int userId)
        {
            var file = _dbContext.Files.Include(f => f.SharedWith).FirstOrDefault(f => f.Id == fileId);
            if (file != null)
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    file.SharedWith.Add(user);
                    _dbContext.SaveChanges();
                }
            }
        }


    }
}
