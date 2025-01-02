using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Presentation.Menus;

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

            var sharedMenu = new SharedWithMenu(_sharedRepository, userId);

            sharedMenu.Open();
        }
    }
}
