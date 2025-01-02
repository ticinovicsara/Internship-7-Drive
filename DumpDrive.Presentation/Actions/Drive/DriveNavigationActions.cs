using DumpDrive.Data.Entities.Models;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class DriveNavigationActions
    {
        private readonly CurrentFolder? _currentFolder;

        private readonly Stack<Folder?> _folderHistory;

        private readonly DiskActionHelper _commandHelper;

        private readonly DriveItemActions _itemActions;

        public DriveNavigationActions(CurrentFolder? currentFolder, Stack<Folder?> folderHistory, DiskActionHelper diskActionHelper, DriveItemActions itemactions)
        {
            _currentFolder = currentFolder;
            _folderHistory = folderHistory;
            _commandHelper = diskActionHelper;
            _itemActions = itemactions;
        }

        public void NavigateToFolder(string command)
        {
            var folderName = command.Substring("udi u mapu".Length).Trim();

            if (TryNavigateToFolder(folderName))
            {
                _commandHelper.DisplayFolderContents();
            }
            else
            {
                Writer.DisplayError($"Navigation to folder '{folderName}' was unsuccessfull.\n");
            }
        }

        public void ReturnToPreviousFolder()
        {
            if (_folderHistory.Count > 0)
            {
                _currentFolder.Folder = _folderHistory.Pop();
                Writer.DisplayInfo($"Returned to folder: {_currentFolder?.Folder?.Name ?? "Root"}.\n");
                _commandHelper.DisplayFolderContents();
            }
            else
            {
                Writer.DisplayError("You are already at the root folder.\n");
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

        public void StartNavigationMode()
        {
            ConsoleKey key;
            var folders = _commandHelper.GetFoldersInCurrentLocation();
            var files = _commandHelper.GetFilesInCurrentLocation();

            var items = folders.Cast<Item>().Concat(files).ToList();
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Writer.DisplayInfo("Use arrows for navigation (press Backspace to go back, Escape to leave navigation mode).\n");
                Writer.PrintItemsInNavigationMode(selectedIndex, items);

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + items.Count) % items.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % items.Count;
                        break;

                    case ConsoleKey.Enter:
                        EnterKeyAction(selectedIndex, items);
                        RefreshItems(items);
                        selectedIndex = 0; 
                        break;

                    case ConsoleKey.Backspace:
                        ReturnToPreviousFolder();
                        RefreshItems(items);
                        selectedIndex = 0;
                        break;

                    case ConsoleKey.Escape:
                        _commandHelper.DisplayFolderContents();
                        return;
                }
            }
        }

        private void EnterKeyAction(int selectedIndex, List<Item> items)
        {
            var selectedItem = items[selectedIndex];

            if (selectedItem is Folder folder)
            {
                if (TryNavigateToFolder(folder.Name))
                {
                    RefreshItems(items);    
                    selectedIndex = 0;
                }
            }
            else if (selectedItem is Files file)
            {
                _itemActions.EditFileContents($"uredi datoteku {file.Name}", false);
            }
        }

        private void RefreshItems(List<Item> items)
        {
            items.Clear();
            items.AddRange(_commandHelper.GetFoldersInCurrentLocation().Cast<Item>()
                .Concat(_commandHelper.GetFilesInCurrentLocation()));
        }
    }
}