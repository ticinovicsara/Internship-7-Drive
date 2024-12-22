using DumpDrive.Domain.Abstractions;
using DumpDrive.Domain.Actions.User;
using DumpDrive.Domain.Actions;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Actions.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Presentation.Factories
{
    public class UserActionFactory
    {
        public static UserAction Create()
        {
            var actions = new List<IAction>
        {
            new UserAddAction(RepositoryFactory.Create<UserRepository>()),
            new UserEditAction(RepositoryFactory.Create<UserRepository>()),
            new UserDeleteAction(RepositoryFactory.Create<UserRepository>()),
            new UsersReadByGroupAction(RepositoryFactory.Create<UserRepository>(), RepositoryFactory.Create<GroupRepository>()),
            new UserAddToGroupAction(
                RepositoryFactory.Create<UserRepository>(),
                RepositoryFactory.Create<GroupRepository>(),
                RepositoryFactory.Create<GroupUserRepository>()),
            new ExitMenuAction()
        };

            var menuAction = new UserAction(actions);
            return menuAction;
        }
    }
}
