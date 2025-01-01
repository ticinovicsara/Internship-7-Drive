using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Presentation.Factories
{
    public class StartMenuFactory
    {
        private readonly LoginAction _loginAction;
        private readonly RegisterAction _registerAction;

        public StartMenuFactory(LoginAction loginAction, RegisterAction registerAction)
        {
            _loginAction = loginAction;
            _registerAction = registerAction;
        }

        public IList<IAction> Create()
        {
            var actions = new List<IAction>
        {
            _loginAction,
            _registerAction,
            new ExitMenuAction()
        };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
