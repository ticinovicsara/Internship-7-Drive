using DumpDrive.Presentation.Abstractions;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Factories;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Data.Entities.Models;

namespace DumpDrive.Presentation.Actions
{
    public class LoginAction : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Login";

        public LoginAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            Console.WriteLine("Login:\n\n");
            string email;
            while (!Reader.TryReadEmail("\nEnter email:", out email))
            {
                if (email == "exit")
                    return;
                Console.WriteLine("Please enter a valid email address.");
            }

            string password;
            while (!Reader.TryReadPassword("\nEnter password:", out password))
            {
                Console.WriteLine("Password cannot be empty.");
            }

            User user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid credentials. Please wait before retrying.\n");
                Thread.Sleep(3000);
                return;
            }

            Console.Clear();
            Console.WriteLine($"Welcome {user.Name}!");
            var userActions = MainMenuFactory.Create(user);
        }

    }
}
