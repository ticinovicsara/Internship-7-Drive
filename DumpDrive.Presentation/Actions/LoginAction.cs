using DumpDrive.Presentation.Abstractions;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Factories;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Presentation.Extensions;
using Npgsql;

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
            Console.Clear();
            Console.WriteLine("Login:\n");
            string email;
            while (!Reader.TryReadEmail("\nEnter email:", out email))
            {
                if (email == "exit")
                    return;
                Console.WriteLine("Please enter a valid email address.");
            }

            User user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid credentials. Please wait before retrying.\n");
                Thread.Sleep(3000);
                return;
            }

            string password;
            string userPass = user.Password;
            while (!Reader.PasswordCheck("\nEnter password:", userPass))
            {
                Console.WriteLine("Invalid credentials. Please wait before retrying.\n");
            }

            Console.Clear();
            Console.WriteLine($"Welcome {user.Name}!");

            var mainMenuFactory = new MainMenuFactory();
            var userActions = mainMenuFactory.Create(user);
            userActions.SetActionIndexes();

            while (true)
            {
                Console.WriteLine("Main Menu:\n");
                foreach (var action in userActions)
                {
                    Console.WriteLine($"{action.MenuIndex}. {action.Name}");
                }

                Console.Write("\n: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice >= userActions.Count)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                userActions[choice - 1].Open();
                if (userActions[choice - 1] is ExitMenuAction)
                    break;
            }
        }

    }
}
