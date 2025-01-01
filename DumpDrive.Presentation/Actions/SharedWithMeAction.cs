using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;

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
            var sharedFiles = _fileRepository.GetSharedFilesByUser(_userId);
            if (sharedFiles.Count == 0)
            {
                Console.WriteLine("No files shared with you.");
            }
            else
            {
                foreach (var file in sharedFiles)
                {
                    Console.WriteLine($"{file.Id}. {file.Name}");
                }
            }
        }
    }
}
