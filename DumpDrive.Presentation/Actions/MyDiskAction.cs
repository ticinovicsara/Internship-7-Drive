using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;

namespace DumpDrive.Presentation.Actions
{
    public class MyDiskAction : IAction
    {
        private readonly FileRepository _fileRepository;
        private readonly int _userId;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "My disk";

        public MyDiskAction(FileRepository fileRepository, int userId)
        {
            _fileRepository = fileRepository;
            _userId = userId;
        }

        public void Open()
        {
            var files = _fileRepository.GetFilesByUser(_userId);
            foreach (var file in files)
            {
                Console.WriteLine($"{file.Id}. {file.Name}");
            }
        }
    }

}
