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
                new LoginAction(),
                new RegisterAction(),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
