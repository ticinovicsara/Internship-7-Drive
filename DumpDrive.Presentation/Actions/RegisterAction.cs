using DumpDrive.Presentation.Abstractions;
using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Domain.Actions
{
    public class RegisterAction : IAction
    {
        public int Index { get; set; }
        public string Name => "Register";

        public void Execute()
        {
            Console.WriteLine("Enter email:");
            var email = Console.ReadLine();

            if (!Reader.TryReadEmail("", email))
            {
                Console.WriteLine("Invalid email format.");
                return;
            }

            if (RepositoryFactory.Create<UserRepository>().Exists(email))
            {
                Console.WriteLine("Email already in use.");
                return;
            }

            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            Console.WriteLine("Confirm password:");
            var confirmPassword = Console.ReadLine();

            if (password != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
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
        }
    }
}
