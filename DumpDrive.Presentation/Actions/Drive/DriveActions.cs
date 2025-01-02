using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class DriveActions : IAction
    {
        private readonly User _user;

        private readonly UserRepository _userRepository;

        private readonly Stack<Folder?> _folderHistory;

        private readonly CurrentFolder _currentFolder;

        private readonly CommentRepository _commentRepository;

        private readonly FolderRepository _folderRepository;

        private readonly FileRepository _filesRepository;

        private readonly ItemRepository _itemRepository;

        private readonly SharedItemRepository _sharedItemRepository;
        public string ActionName { get; set; } = "My Disk";
        public DriveActions(SharedItemRepository sharedItemRepository,ItemRepository itemRepository ,CurrentFolder currentFolder, CommentRepository commentRepository, FolderRepository folderRepository, FileRepository fileRepository, Stack<Folder?> folderHistory,UserRepository userRepository ,User user)
        {
            _sharedItemRepository = sharedItemRepository;
            _itemRepository = itemRepository;
            _folderHistory = folderHistory;
            _userRepository = userRepository;
            _user = user;
            _commentRepository = commentRepository;
            _folderRepository = folderRepository;
            _filesRepository = fileRepository;
            _currentFolder = new CurrentFolder();
        }

        public void Open()
        {
            var commandHelper = new DiskActionHelper(_user, _userRepository, _currentFolder);
            var sharingActions = new DriveSharingActions(_user, _itemRepository, _sharedItemRepository, _userRepository, commandHelper);
            var itemActions = new DiskItemActions(_itemRepository, _currentFolder, _commentRepository, _folderRepository, _filesRepository, _userRepository, _user, commandHelper);
            var navigationActions = new DiskNavigationActions(_currentFolder, _folderHistory, commandHelper, itemActions);

            commandHelper.DisplayFolderContents();

            var commandDictionary = new Dictionary<Func<string, bool>, Action<string>>
            {
                { command => Reader.IsCommand(command, "clear"), _ => commandHelper.DisplayFolderContents() },

                { command => Reader.IsCommand(command, "help"), _ => Writer.PrintCommands() },

                { command => Reader.StartsWithCommand(command, "stvori mapu"), itemActions.CreateFolderInCurrentLocation },

                { command => Reader.StartsWithCommand(command, "stvori datoteku"), itemActions.CreateFileInCurrentLocation},

                { command => Reader.StartsWithCommand(command, "udi u mapu"), navigationActions.NavigateToFolder },

                { command => Reader.IsCommand(command, "navigacijski mod"), _ => navigationActions.StartNavigationMode()},

                { command => Reader.StartsWithCommand(command, "uredi datoteku"), command => itemActions.EditFileContents(command, false) },

                { command => Reader.StartsWithCommand(command, "izbrisi"), itemActions.DeleteItem },

                { command => Reader.StartsWithCommand(command, "promjeni naziv"), itemActions.ChangeItemName },

                { command => Reader.StartsWithCommand(command, "podijeli"), sharingActions.ShareItem },

                { command => Reader.StartsWithCommand(command, "prestani dijeliti"), sharingActions.StopSharingItem },

                { command => Reader.IsCommand(command, "nazad"), _ => navigationActions.ReturnToPreviousFolder() },
            };

            Reader.TryReadCommand(commandDictionary);
        }
    }
}
