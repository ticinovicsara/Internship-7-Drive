using DumpDrive.Domain.Repositories;

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

            // Promena imena
            if (TryChangeName(user))
            {
                Console.WriteLine("Name successfully changed\n");
            }

            // Promena lozinke
            if (TryChangePassword(user))
            {
                Console.WriteLine("Password successfully changed\n");
            }
        }

        private bool TryChangeName(User user)
        {
            string newName;
            if (Reader.TryReadLine("Enter new name:", out newName))
            {
                user.Name = newName;
                _userRepository.Update(user);
                return true;
            }
            return false;
        }

        private bool TryChangePassword(User user)
        {
            string newPassword;
            if (Reader.TryReadPassword("Unesite novu lozinku:", out newPassword))
            {
                // Verifikacija lozinke (ako je potrebno) ili hashiranje pre nego što se sačuva
                user.Password = newPassword; // Preporučuje se da ovde koristiš funkcionalnost za hashiranje
                _userRepository.Update(user);
                return true;
            }
            return false;
        }
    }

}