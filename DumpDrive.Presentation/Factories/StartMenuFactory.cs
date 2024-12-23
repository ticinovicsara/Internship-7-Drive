using DumpDrive.Domain.Abstractions;
using DumpDrive.Domain.Actions;

namespace DumpDrive.Presentation.Factories
{
    public class StartMenuFactory
    {
        public static IList<IAction> Create()
        {
            var actions = new List<IAction>
            {
                new LoginUser(),
                new RegisterUser(),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
