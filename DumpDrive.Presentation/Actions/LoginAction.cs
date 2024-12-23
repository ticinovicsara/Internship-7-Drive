using DumpDrive.Presentation.Abstractions;
using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Factories;
using DumpDrive.Presentation.Abstractions;
using static System.Net.Mime.MediaTypeNames;

namespace DumpDrive.Domain.Actions
{
    public class LoginAction : IAction
    {
        public int Index { get; set; }
        public string Name => "Login";

        public void Execute()
        {
            Console.WriteLine("Enter email:");
            var email = Console.ReadLine();

            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            var user = RepositoryFactory.Create<UserRepository>().FindByEmailAndPassword(email, password);

            if (user == null)
            {
                Console.WriteLine("Invalid credentials. Please wait 30 seconds before retrying.");
                Thread.Sleep(30000);
                return;
            }

            Console.WriteLine($"Welcome {user.Name}!");
            Application.SetMenu(MainMenuFactory.Create());
        }
    }
}
