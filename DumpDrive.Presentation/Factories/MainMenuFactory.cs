using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Extensions;

namespace DumpDrive.Presentation.Factories
{
    public class MainMenuFactory
    {
        private readonly FileRepository _fileRepository;
        private readonly UserRepository _userRepository;
        private readonly int _userId;

        public MainMenuFactory()
        {
        }

        public IList<IAction> Create()
        {
            var actions = new List<IAction>
            {
                new MyDiskAction(_fileRepository, _userId),
                new SharedWithMeAction(_fileRepository, _userId),
                new ProfileAction(_userRepository, _userId),
                new ExitMenuAction()
            };

            actions.SetActionIndexes();
            return actions;
        }
    }
}
