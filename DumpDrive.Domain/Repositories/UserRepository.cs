﻿using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;

namespace DumpDrive.Domain.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DumpDriveDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType AddUser(User user)
        {
            DbContext.Users.Add(user);

            return SaveChanges();
        }

        public ResponseResultType Create(string email, string password)
        {
            if (DbContext.Users.Any(u => u.Email == email))
            {
                return ResponseResultType.Conflict;
            }

            var user = new User(email, password, "Name", "Surname");

            DbContext.Users.Add(user);

            return SaveChanges();
        }


        public ResponseResultType Update(User user, int id)
        {
            var userToUpdate = GetById(id);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;

            return SaveChanges();
        }

        public User GetByEmail(string email) => DbContext.Users.FirstOrDefault(u => u.Email == email.ToLower());
        public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.Id == id);
        public ICollection<User> GetAll() => DbContext.Users.ToList();

        public User? FindByEmailAndPassword(string email, string password)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
