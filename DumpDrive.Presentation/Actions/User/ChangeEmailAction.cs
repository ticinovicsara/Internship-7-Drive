using DumpDrive.Domain.Repositories;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Presentation.Abstractions;

namespace DumpDrive.Presentation.Actions
{
    public class ChangeEmailAction : IAction
    {
        private readonly UserRepository _userRepository;

        private readonly User _user;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Change Email";
        public ChangeEmailAction(UserRepository userRepository, User user)
        {
            _userRepository = userRepository;
            _user = user;
        }

        public void Open()
        {
            var hasAccessToChange = Reader.PasswordCheck("Enter your password to continue", _user.Password);

            if (!hasAccessToChange)
                return;

            string email;
            do
            {
                email = Reader.TryReadEmail("Enter your new email address");
            }
            while (Reader.IsEmailAlreadyInUse(email, _userRepository));

            _user.Email = email;
            var result = _userRepository.Update(_user, _user.Id);

            Writer.DisplayInfo(result == ResponseResultType.Success
                 ? "\nEmail updated successfully!"
                 : "\nFailed to update email. Please try again.");

            Reader.PressAnyKey();
        }
    }
}
