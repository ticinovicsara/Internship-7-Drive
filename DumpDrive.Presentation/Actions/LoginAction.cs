using DumpDrive.Presentation.Abstractions;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Factories;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class LoginAction : IAction
    {
        private readonly MainMenuFactory _mainMenuFactory;
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Login";

        public LoginAction(MainMenuFactory mainMenuFactory, UserRepository userRepository)
        {
            _mainMenuFactory = mainMenuFactory;
            _userRepository = userRepository;
        }

        public void Open()
        {
            string email;
            while (!Reader.TryReadEmail("\nEnter email:", out email))
            {
                Console.WriteLine("Please enter a valid email address.");
            }

            string password;
            while (!Reader.TryReadPassword("\nEnter password:", out password))
            {
                Console.WriteLine("Password cannot be empty.");
            }

            var user = _userRepository.GetByEmailAndPassword(email, password);
            if(user != null)
            {
                UserContext.UserId = user.Id;
            }

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid credentials. Please wait 30 seconds before retrying.\n");
                Thread.Sleep(30000);
                return;
            }

            Console.Clear();
            Console.WriteLine($"Welcome {user.Name}!");
            Application.SetMenu(_mainMenuFactory.Create());
        }
    }
}
