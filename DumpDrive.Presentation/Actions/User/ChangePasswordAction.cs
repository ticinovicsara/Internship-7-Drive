using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class ChangePasswordAction : IAction
    {
        private readonly UserRepository _userRepository;

        private readonly User _user;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Change Password";
        public ChangePasswordAction(UserRepository userRepository, User user)
        {
            _userRepository = userRepository;
            _user = user;
        }

        public void Open()
        {
            var hasAccessToChange = Reader.PasswordCheck("Enter your password to continue", _user.Password);

            if (!hasAccessToChange)
                return;

            var password = Reader.ConfirmPassword("Enter your new password");

            _user.Password = password;
            var result = _userRepository.Update(_user, _user.Id);

            Writer.Write(result == ResponseResultType.Success
                  ? "\nPassword updated successfully!"
                  : "\nFailed to update Password. Please try again.;");

            Reader.PressAnyKey();
        }
    }
}
