using DumpDrive.Domain.Abstractions;
using DumpDrive.Domain.Actions;
using DumpDrive.Domain.Actions.User;
using DumpDrive.Presentation.Abstrations;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;
using DumpDrive.Domain.Repositories;

namespace DumpDrive.Presentation.Factories
{
    public class UserFactory
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
