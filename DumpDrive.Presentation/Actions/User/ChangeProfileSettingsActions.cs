using DumpDrive.Data.Entities.Models;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Factories;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Presentation.Actions
{
    public class ChangeProfileSettingsActions : IAction
    {
        private readonly User _user;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Profile settings";
        public ChangeProfileSettingsActions(User user)
        {
            _user = user;
        }

        public void Open()
        {
            var settingsActions = ProfileSettingsMenuFactory.Create(_user);

            Console.Clear();
            settingsActions.PrintActionsAndOpen();
        }       
    }
}
