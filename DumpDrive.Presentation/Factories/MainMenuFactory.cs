using DumpDrive.Presentation.Abstrations;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Domain.Factories
{
    public class MainMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>
        {
            UserActionsFactory.Create(),
            new ExitMenuAction(),
        };

            actions.SetActionIndexes();

            return actions;
        }
    }
}
