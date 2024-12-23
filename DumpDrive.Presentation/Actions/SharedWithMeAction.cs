using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;

namespace DumpDrive.Presentation.Actions
{
    public class SharedWithMeAction : IAction
    {
        private readonly FileRepository _fileRepository;
        private readonly int _userId;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Shared with me";

        public class SharedWithMeAction(IList<IAction> (actions) : base(actions))
        {
            Name = "User menu";
        }

        public SharedWithMeAction(FileRepository fileRepository, int userId)
        {
            _fileRepository = fileRepository;
            _userId = userId;
        }

        public void Open()
        {
            var sharedFiles = _fileRepository.GetSharedWithUser(_userId);
            foreach (var file in sharedFiles)
            {
                Console.WriteLine($"{file.Id}. {file.Name}");
            }
        }
    }
}
