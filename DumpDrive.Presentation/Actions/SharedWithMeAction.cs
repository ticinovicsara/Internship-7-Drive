using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions.Menus.SharedWith;
using DumpDrive.Presentation.Extensions;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class SharedWithMeAction : IAction
    {
        private readonly SharedRepository _sharedRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Shared with me";


        public SharedWithMeAction(SharedRepository sharedRepository)
        {
            _sharedRepository = sharedRepository;
        }

        public void Open()
        {
            var userId = UserContext.UserId;

            var actions = new List<IAction>
            {
                 new SharedWithMenu(_sharedRepository, userId),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
        }
    }
}
