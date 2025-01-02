using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;

namespace DumpDrive.Domain.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DumpDriveDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(string email, string password)
        {
            var user = new User(email, password);

            DbContext.Users.Add(user);

            return SaveChanges();
        }

        public ResponseResultType Update(User user, int userId)
        {
            var userToUpdate = DbContext.Users.Find(userId);

            if (userToUpdate == null)
                return ResponseResultType.NotFound;

            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;

            return SaveChanges();
        }

        public User? GetById(int userId) => DbContext.Users.FirstOrDefault(u => u.Id == userId);
        public User? GetByEmail(string email) => DbContext.Users.FirstOrDefault(u => u.Email == email);

        public List<Folder> GetUserFolders(User user) => DbContext.Folders.Where(f => f.DriveId == user.DriveId).ToList();
        public List<Files> GetUserFiles(User user) => DbContext.Files.Where(f => f.DriveId == user.DriveId).ToList();
    }
}
