using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Factories;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Helpers;

namespace Drive.Presentation.Helpers
{
    public class DriveActionHelper
    {

        private readonly User _user;

        private readonly UserRepository _userRepository;

        private readonly CurrentFolder? _currentFolder;

        private readonly SharedItemRepository _sharedItemRepository;

        private readonly ItemRepository _itemRepository;

        private readonly FileRepository _filesRepository = RepositoryFactory.Create<FileRepository>();

        public DriveActionHelper(User user, UserRepository userRepository, CurrentFolder? currentFolder)
        {
            _user = user;
            _userRepository = userRepository;
            _currentFolder = currentFolder;
        }

        public DriveActionHelper(ItemRepository itemRepository, SharedItemRepository sharedItemRepository, User user)
        {
            _sharedItemRepository = sharedItemRepository;
            _itemRepository = itemRepository;
            _user = user;
        }
        public List<Folder> GetFoldersInCurrentLocation()
        {
            return _currentFolder.Folder == null
            ? _userRepository.GetUserFolders(_user).Where(f => f.ParentFolderId == null).ToList()
            : _userRepository.GetUserFolders(_user).Where(f => f.ParentFolderId == _currentFolder.Folder.ItemId).ToList();
        }

        public List<Files> GetFilesInCurrentLocation()
        {
            return _currentFolder.Folder == null
            ? _userRepository.GetUserFiles(_user).Where(f => f.ParentFolderId == null).ToList()
            : _userRepository.GetUserFiles(_user).Where(f => f.ParentFolderId == _currentFolder.Folder.ItemId).ToList();
        }

        public Folder CreateFolder(string folderName)
        {
            return _currentFolder.Folder == null
                ? new Folder(folderName, null, _user.DriveId)
                : new Folder(folderName, _currentFolder.Folder.ItemId, _user.DriveId);
        }

        public Files CreateFile(string fileName)
        {
            return _currentFolder.Folder == null
                ? new Files(fileName, " ", null, _user.DriveId)
                : new Files(fileName, " ", _currentFolder.Folder.ItemId, _user.DriveId);
        }

        public bool IsNameDuplicate(string name)
        {
            var folders = GetFoldersInCurrentLocation();
            var files = GetFilesInCurrentLocation();

            return Reader.CheckIfNameAlreadyExists(name, folders, files);
        }

        public void DisplayFolderContents()
        {
            var folders = GetFoldersInCurrentLocation();
            var files = GetFilesInCurrentLocation();

            Writer.PrintCurrentFolderContent(_currentFolder, folders, files);
        }

        public void DisplaySharedItems()
        {
            var sharedItems = _sharedItemRepository.GetByUserId(_user.Id);

            List<Item> items = new List<Item>();

            foreach (var sharedItem in sharedItems)
            {
                var item = _itemRepository.GetByItemId(sharedItem.ItemId);

                if (item is not null)
                    items.Add(item);
            }

            Writer.PrintSharedContent(items);
        }

        public Files? GetFile(string fileName, bool isShared)
        {
            if (isShared)
            {
                var sharedFile = _sharedItemRepository.GetByNameAndUserId(fileName, _user.Id);
                if (sharedFile == null)
                    return null;

                return _filesRepository.GetById(sharedFile.ItemId);
            }

            return _filesRepository.GetByName(fileName, _user);
        }
    }
}
