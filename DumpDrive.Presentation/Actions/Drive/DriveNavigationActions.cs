using DumpDrive.Data.Entities.Models;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class DriveNavigationActions
    {
        private readonly FolderContext? _currentFolder;

        private readonly Stack<Folder?> _folderHistory;

        private readonly DriveActionHelper _commandHelper;

        public DriveNavigationActions(FolderContext? currentFolder, Stack<Folder?> folderHistory, DriveActionHelper diskActionHelper, DriveItemActions itemactions)
        {
            _currentFolder = currentFolder;
            _folderHistory = folderHistory;
            _commandHelper = diskActionHelper;
        }

        public void NavigateToFolder(string command)
        {
            var folderName = command.Substring("cd".Length).Trim();

            if (TryNavigateToFolder(folderName))
            {
                _commandHelper.DisplayFolderContents();
            }
            else
            {
                Writer.Error($"Navigation to folder '{folderName}' was unsuccessfull.\n");
            }
        }

        public void ReturnToPreviousFolder()
        {
            if (_folderHistory.Count > 0)
            {
                _currentFolder.Folder = _folderHistory.Pop();
                Writer.Write($"Returned to folder: {_currentFolder?.Folder?.Name ?? "Root"}.\n");
                _commandHelper.DisplayFolderContents();
            }
            else
            {
                Writer.Error("You are already at the root folder.\n");
            }
        }

        private bool TryNavigateToFolder(string folderName)
        {
            var folders = _commandHelper.GetFoldersInCurrentLocation();

            var targetFolder = folders.FirstOrDefault(f => f.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase));

            if (targetFolder != null)
            {
                _folderHistory.Push(_currentFolder.Folder);
                _currentFolder.Folder = targetFolder;
                return true;
            }

            return false;
        }
    }
}