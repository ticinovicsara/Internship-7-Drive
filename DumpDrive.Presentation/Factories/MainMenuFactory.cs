using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Presentation.Factories
{
    public class MainMenuFactory
    {
        private readonly SharedRepository _sharedRepository;
        private readonly DriveRepository _driveRepository;
        private readonly UserRepository _userRepository;
        private readonly int _userId;

        public MainMenuFactory(SharedRepository sharedRepository, DriveRepository driveRepository, UserRepository userRepository, int userId)
        {
            _sharedRepository = sharedRepository;
            _driveRepository = driveRepository;
            _userRepository = userRepository;
            _userId = userId;
        }

        public IList<IAction> Create()
        {
            var actions = new List<IAction>
            {
                 new MyDriveAction(_driveRepository, _sharedRepository, _userRepository).Create(_userId),
                 new SharedWithMeAction(_sharedRepository).Create(_userId),
                 new ProfileAction(_userRepository, _userId).Create(),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
