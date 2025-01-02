using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Presentation.Factories
{
    public class StartMenuFactory
    {
        public static IList<IAction> Create()
        {
            var actions = new List<IAction>
            {
                new RegisterAction(RepositoryFactory.Create<UserRepository>()),
                new LoginAction(RepositoryFactory.Create<UserRepository>()),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
