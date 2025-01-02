using DumpDrive.Presentation.Abstractions;
using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Presentation.Factories;

namespace DumpDrive.Presentation.Actions
{
    public class RegisterAction : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; }  = "Register";

        public RegisterAction(UserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public void Open()
        {
            Console.WriteLine("Register:\n\n");

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
                    Console.WriteLine("Passwords do not match.\n");
                }
            }

            var captcha = Writer.CaptchaGenerator();
            Console.WriteLine($"CAPTCHA: {captcha}");
            Console.WriteLine("Repeat CAPTCHA:");
            var captchaInput = Console.ReadLine();

            if (captcha != captchaInput)
            {
                Console.Clear();
                Console.WriteLine("CAPTCHA does not match.\n");
                return;
            }

            RepositoryFactory.Create<UserRepository>().Add(email, password);
            Console.Clear();
            Console.WriteLine("\nRegistration successful! You can now log in.\n");
            Reader.PressAnyKey();
        }
    }
}
