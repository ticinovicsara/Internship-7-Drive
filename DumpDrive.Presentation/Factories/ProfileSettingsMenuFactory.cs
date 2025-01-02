using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Presentation.Factories
{
    public class ProfileSettingsMenuFactory
    {
        public static IList<IAction> Create(User user)
        {
            var actions = new List<IAction>
            {
                new ChangeEmailAction(RepositoryFactory.Create<UserRepository>(), user),
                new ChangePasswordAction(RepositoryFactory.Create<UserRepository>(), user),
                new ExitMenuAction(),
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
