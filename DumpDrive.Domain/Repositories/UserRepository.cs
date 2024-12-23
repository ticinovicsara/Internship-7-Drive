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

        public ResponseResultType Add(User user)
        {
            DbContext.Users.Add(user);

            return SaveChanges();
        }

        public ResponseResultType Update(User user, int id)
        {
            var userToUpdate = DbContext.Users.Find(id);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Surname = user.Surname;

            return SaveChanges();
        }

        public User GetByEmail(string email) => DbContext.Users.FirstOrDefault(u => u.Email == email);
        public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.Id == id);
        public ICollection<User> GetAll() => DbContext.Users.ToList();

        public User? FindByEmailAndPassword(string email, string password)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }


    }
}
