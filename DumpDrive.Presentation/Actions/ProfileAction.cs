using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using BCrypt.Net;

namespace DumpDrive.Presentation.Actions
{
    public class ProfileAction : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly int _userId;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Profile settings\n";

        public ProfileAction(UserRepository userRepository, int userId)
        {
            _userRepository = userRepository;
            _userId = userId;
        }

        public void Open()
        {
            var user = _userRepository.GetUserById(_userId);
            Console.WriteLine($"Current email: {user.Email}");
            Console.WriteLine($"Current ime: {user.Name}");

            if (TryChangeName(user))
            {
                Console.WriteLine("Name successfully changed\n");
            }

            if (TryChangePassword(user))
            {
                Console.WriteLine("Password successfully changed\n");
            }
        }

        private bool TryChangeName(User user)
        {
            string newName;
            if (Reader.TryReadLine("Enter new name: ", out newName))
            {
                user.Name = newName;
                _userRepository.Update(user);
                return true;
            }
            return false;
        }

        private bool TryChangePassword(User user)
        {
            string currentPassword;
            string newPassword;
            string confirmPassword;

            if (!Reader.TryReadPassword("Enter current password: ", out currentPassword))
            {
                Console.WriteLine("Password is not changed");
                return false;
            }

            if (!BCrypt.Net.BCrypt.Verify(currentPassword, user.Password))
            {
                Console.WriteLine("Password is incorrect");
                return false;
            }

            if (!Reader.TryReadPassword("Enter new password: ", out newPassword))
            {
                Console.WriteLine("Password is not changed");
                return false;
            }

            if (!Reader.TryReadPassword("Validate new password:", out confirmPassword))
            {
                Console.WriteLine("Password is not changed");
                return false;
            }

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return false;
            }

            _userRepository.Update(user);

            Console.WriteLine("Passwor changed successfully.");
            return true;
        }
    }

}