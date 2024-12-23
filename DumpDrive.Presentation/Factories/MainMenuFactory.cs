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
    public class MainMenuFactory
    {
        public static IList<IAction> Create()
        {
            var userRepository = new UserRepository();

            var actions = new List<IAction>
            {
                new LoginUser(RepositoryFactory.Create<UserRepository>()),
                new RegisterUser(RepositoryFactory.Create<UserRepository>()),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
