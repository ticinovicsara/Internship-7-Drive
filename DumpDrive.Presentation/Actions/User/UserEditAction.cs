using DumpDrive.Domain.Abstractions;
using DumpDrive.Domain.Enums;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Actions.User
{
    public class UserEditAction : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Edit user";

        public UserEditAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            var users = _userRepository.GetAll();
            Writer.Write(users);

            Console.WriteLine("\nType ID of a user you want to edit or exit");
            var isRead = Reader.TryReadNumber(out var userId);
            if (!isRead)
            {
                Writer.Error("Error: Not a number");
                return;
            }

            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user is null)
            {
                Console.WriteLine($"User with id: '{userId}' is not found");
                return;
            }

            Console.WriteLine("<Enter> to skip editting certain field");

            if (Reader.TryReadLine($"First name: {user.Name}", out var name))
                user.Surname = name;

            if (Reader.TryReadLine($"Last name: {user.Surname}", out var surname))
                user.Surname = surname;

            var responseResult = _userRepository.Update(user, userId);

            switch (responseResult)
            {
                case ResponseResultType.Success:
                    Writer.Write(user);
                    break;
                case ResponseResultType.NoChanges:
                    Console.WriteLine("No changes applied");
                    break;
                default:
                    Console.WriteLine("Error occurred while updating user");
                    break;
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}
