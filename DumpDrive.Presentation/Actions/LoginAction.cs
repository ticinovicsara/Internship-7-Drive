using DumpDrive.Presentation.Abstractions;
using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Factories;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class LoginAction : IAction
    {
        private readonly MainMenuFactory _mainMenuFactory;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Login";

        public LoginAction(MainMenuFactory mainMenuFactory)
        {
            _mainMenuFactory = mainMenuFactory;
        }

        public void Open()
        {
            string email;
            while (!Reader.TryReadEmail("Enter email:", out email))
            {
                Console.WriteLine("Please enter a valid email address.");
            }

            string password;
            while (!Reader.TryReadPassword("Enter password:", out password))
            {
                Console.WriteLine("Password cannot be empty.");
            }

            var user = RepositoryFactory.Create<UserRepository>().FindByEmailAndPassword(email, password);

            if (user == null)
            {
                Console.WriteLine("Invalid credentials. Please wait 30 seconds before retrying.");
                Thread.Sleep(30000);
                return;
            }

            Console.WriteLine($"Welcome {user.Name}!");
            Application.SetMenu(_mainMenuFactory.Create());
        }
    }
}
