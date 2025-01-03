using DumpDrive.Presentation.Helpers;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;

namespace DumpDrive.Presentation.Actions
{
    public class DriveActions : IAction
    {
        private readonly User _user;

        private readonly UserRepository _userRepository;
        private readonly Stack<Folder?> _folderHistory;
        private readonly FolderContext _currentFolder;
        private readonly CommentRepository _commentRepository;
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _filesRepository;
        private readonly ItemRepository _itemRepository;
        private readonly SharedItemRepository _sharedItemRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "My Drive";
        public DriveActions(SharedItemRepository sharedItemRepository,ItemRepository itemRepository , FolderContext currentFolder, CommentRepository commentRepository, FolderRepository folderRepository, FileRepository fileRepository, Stack<Folder?> folderHistory,UserRepository userRepository ,User user)
        {
            _sharedItemRepository = sharedItemRepository;
            _itemRepository = itemRepository;
            _folderHistory = folderHistory;
            _userRepository = userRepository;
            _user = user;
            _commentRepository = commentRepository;
            _folderRepository = folderRepository;
            _filesRepository = fileRepository;
            _currentFolder = new FolderContext();
        }

        public void Open()
        {
            var commandHelper = new DriveActionHelper(_user, _userRepository, _currentFolder);
            var sharingActions = new DriveSharingActions(_user, _itemRepository, _sharedItemRepository, _userRepository, commandHelper);
            var itemActions = new DriveItemActions(_itemRepository, _currentFolder, _commentRepository, _folderRepository, _filesRepository, _userRepository, _user, commandHelper);
            var navigationActions = new DriveNavigationActions(_currentFolder, _folderHistory, commandHelper, itemActions);

            commandHelper.DisplayFolderContents();

            var commandDictionary = new Dictionary<Func<string, bool>, Action<string>>
            {
                { command => Reader.IsCommand(command, "clear"), _ => commandHelper.DisplayFolderContents() },

                { command => Reader.IsCommand(command, "help"), _ => Writer.PrintCommands() },

                { command => Reader.StartsWithCommand(command, "make folder"), itemActions.CreateFolderInCurrentLocation },

                { command => Reader.StartsWithCommand(command, "make file"), itemActions.CreateFileInCurrentLocation},

                { command => Reader.StartsWithCommand(command, "cd"), navigationActions.NavigateToFolder},

                { command => Reader.StartsWithCommand(command, "edit file"), command => itemActions.EditFileContents(command, false) },

                { command => Reader.StartsWithCommand(command, "delete"), itemActions.DeleteItem },

                { command => Reader.StartsWithCommand(command, "change name"), itemActions.ChangeItemName },

                { command => Reader.StartsWithCommand(command, "share"), sharingActions.ShareItem },

                { command => Reader.StartsWithCommand(command, "stop sharing"), sharingActions.StopSharingItem },

                { command => Reader.IsCommand(command, "return"), _ => navigationActions.ReturnToPreviousFolder() }

            };

            Reader.TryReadCommand(commandDictionary);
        }
    }
}
