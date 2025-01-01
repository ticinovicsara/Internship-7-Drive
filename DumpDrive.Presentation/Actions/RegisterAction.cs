using DumpDrive.Presentation.Abstractions;
using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Presentation.Factories;

namespace DumpDrive.Presentation.Actions
{
    public class RegisterAction : IAction
    {
        private readonly MainMenuFactory _mainMenuFactory;

        public int MenuIndex { get; set; }
        public string Name { get; set; }  = "Register";

        public RegisterAction(MainMenuFactory mainMenuFactory) 
        { 
            _mainMenuFactory = mainMenuFactory;
        }

        public void Open()
        {
            string email;
            while (!Reader.TryReadEmail("Enter email:", out email))
            {
                Console.WriteLine("Please enter a valid email address.\n");
            }
            var existingUser = RepositoryFactory.Create<UserRepository>().GetByEmail(email);
            if (existingUser != null)
            {
                Console.WriteLine("Email already in use.\n");
                return;
            }

            string password;
            while (!Reader.TryReadPassword("Enter password:", out password))
            {
                Console.WriteLine("Password cannot be empty.");
            }

            string confirmPassword;
            while (!Reader.TryReadPassword("Confirm password:", out confirmPassword) || password != confirmPassword)
            {
                if (password != confirmPassword)
                {
                    Console.WriteLine("Passwords do not match.");
                }
                else
                {
                    Console.WriteLine("Please enter a valid password.");
                }
            }

            var captcha = Writer.CaptchaGenerator();
            Console.WriteLine($"CAPTCHA: {captcha}");
            Console.WriteLine("Repeat CAPTCHA:");
            var captchaInput = Console.ReadLine();

            if (captcha != captchaInput)
            {
                Console.WriteLine("CAPTCHA does not match.");
                return;
            }

            RepositoryFactory.Create<UserRepository>().Create(email, password);
            Console.WriteLine("Registration successful! You can now log in.");
            Application.SetMenu(_mainMenuFactory.Create());
        }
    }
}
