using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class MyDriveAction : IAction
    {
        private readonly DriveRepository _driveRepository;
        private readonly SharedRepository _sharedRepository;
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "My drive";

        public MyDriveAction(DriveRepository driveRepository, SharedRepository sharedRepository, UserRepository userRepository)
        {
            _driveRepository = driveRepository;
            _sharedRepository = sharedRepository;
            _userRepository = userRepository;
        }

        public void Open()
        {
            var userId = UserContext.UserId;
            var files = _driveRepository.GetUserFiles(userId);
            foreach (var file in files)
            {
                Console.WriteLine($"{file.Id}. {file.Name}");
            }
        }
    }

}
