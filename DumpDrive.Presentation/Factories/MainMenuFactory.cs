using DumpDrive.Domain.Abstractions;
using DumpDrive.Domain.Actions;
using DumpDrive.Presentation.Abstrations;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Presentation.Factories
{
    public class MainMenuFactory
    {
        public static IList<IAction> CreateActions(int userId)
        {
            var fileRepository = new FileRepository();
            var userRepository = new UserRepository();

            var actions = new List<IAction>
        {
            new MyDiskAction(fileRepository, userId),
            new SharedWithMeAction(fileRepository, userId),
            new ProfileSettingsAction(userRepository, userId),
            new ExitMenuAction(),
        };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
