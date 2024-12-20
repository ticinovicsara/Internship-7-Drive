using DumpDrive.Domain.Abstractions;
using DumpDrive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Domain.Actions.User
{
    public class UserAddAction : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Add user";

        public UserAddAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            Reader.ReadInput("First name", out var firstName);
            Reader.ReadInput("Last name", out var lastName);
            var user = new Data.Entities.Models.User(firstName, lastName);

            var responseResult = _userRepository.Add(user);
            if (responseResult is ResponseResultType.Success)
            {
                Writer.Write(user);
                Console.ReadLine();

                return;
            }

            Console.WriteLine("Failed to add user, no changes saved!");
            Console.ReadLine();
        }
    }
}
