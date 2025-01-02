using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Domain.Enums;

namespace DumpDrive.Presentation.Actions
{
    public class DriveSharingActions
    {
        private readonly UserRepository _userRepository;
        private readonly SharedItemRepository _sharedItemRepository;
        private readonly DriveActionHelper _commandHelper;
        private readonly ItemRepository _itemRepository;

        private readonly User _user;
        public DriveSharingActions(User user, ItemRepository itemRepository, SharedItemRepository sharedItemRepository,UserRepository userRepository, DriveActionHelper commandHelper)
        {
            _user = user;
            _itemRepository = itemRepository;
            _sharedItemRepository = sharedItemRepository;
            _userRepository = userRepository;
            _commandHelper = commandHelper;
        }

        public void ShareItem(string command)
        {
            var itemPart = 1;
            var userPart = 3;

            var (itemName, userEmail) = Reader.ParseShareCommand(command, 4, itemPart, userPart);
            if (itemName == null || userEmail == null)
                return;

            var userToReceiveItem = _userRepository.GetByEmail(userEmail);
            if (userToReceiveItem is null || userToReceiveItem.Email == _user.Email)
            {
                Writer.Error($"User {userEmail} does not exist\n");
                return;
            }

            var selectedItem = GetItemByName(itemName);
            if (selectedItem == null) 
                return;

            if (Reader.IsAlreadyShared(itemName, userToReceiveItem.Id, _sharedItemRepository))
                return;

            ShareSelectedItem(selectedItem, userToReceiveItem, itemName, userEmail);

            if (selectedItem is Folder folder)
                ShareFolderContents(folder, userToReceiveItem);
        }

        private Item? GetItemByName(string itemName)
        {
            var itemFile = _commandHelper.GetFilesInCurrentLocation().Find(f => f.Name == itemName);
            var itemFolder = _commandHelper.GetFoldersInCurrentLocation().Find(f => f.Name == itemName);

            if (itemFile is not null)
            {
                return itemFile;
            }
            else if (itemFolder is not null)
            {
                return itemFolder;
            }
            else
            {
                Writer.Error($"Item {itemName} does not exist\n");
                return null;
            }
        }

        private void ShareSelectedItem(Item selectedItem, User userToReceiveItem, string itemName, string userEmail)
        {
            var itemToShare = new SharedItem(selectedItem.ItemId, userToReceiveItem.Id, selectedItem.Name);
            var result = _sharedItemRepository.Add(itemToShare);

            if (result == ResponseResultType.Success)
            {
                Writer.Write($"Item {itemName} shared with user {userEmail}\n");
            }
            else
            {
                Writer.Error($"Failed to share item {itemName} with user {userEmail}\n");
            }
        }

        private void ShareFolderContents(Folder folder, User userToReceiveItem)
        {
            foreach (var subFolder in folder.Items.OfType<Folder>())
            {
                var sharedSubFolder = new SharedItem(subFolder.ItemId, userToReceiveItem.Id, subFolder.Name);
                _sharedItemRepository.Add(sharedSubFolder);
                ShareFolderContents(subFolder, userToReceiveItem);
            }

            foreach (var file in folder.Items.OfType<Files>())
            {
                var sharedFile = new SharedItem(file.ItemId, userToReceiveItem.Id, file.Name);
                _sharedItemRepository.Add(sharedFile);
            }
        }

        public void StopSharingItem(string command)
        {
            var itemPart = 2;
            var userPart = 4;

            var (itemName, userEmail) = Reader.ParseShareCommand(command, 5, itemPart, userPart);
            if (itemName == null || userEmail == null) return;

            var user = _userRepository.GetByEmail(userEmail);
            if (user is null)
            {
                Writer.Error($"User {userEmail} does not exist\n");
                return;
            }

            var sharedItem = GetSharedItem(itemName, user.Id);
            if (sharedItem == null) return;

            var fullSharedItem = _itemRepository.GetByItemIdWithItems(sharedItem.ItemId);

            if (fullSharedItem is Folder folder)
                StopSharingFolderContents(folder, user.Id);
            
            StopSharing(sharedItem, itemName, userEmail);
        }

        public SharedItem? GetSharedItem(string itemName, int userId)
        {
            var sharedItem = _sharedItemRepository.GetByNameAndUserId(itemName, userId);

            if (sharedItem == null)
                Writer.Error($"Item {itemName} is not shared or does not exist\n");

            return sharedItem;
        }

        public void StopSharing(SharedItem sharedItem, string itemName, string userEmail)
        {
            var result = _sharedItemRepository.Delete(sharedItem.SharedItemId);
            if (result == ResponseResultType.Success)
            {
                Writer.Write($"You stopped sharing item {itemName} with user {userEmail}\n");
            }
            else
            {
                Writer.Error($"Failed to stop sharing item {itemName} with user {userEmail}\n");
            }
        }

        public void StopSharingFolderContents(Folder folder, int userId)
        {
            foreach (var subFolder in folder.Items.OfType<Folder>())
            {
                var sharedSubFolder = _sharedItemRepository.GetByNameAndUserId(subFolder.Name, userId);
                if (sharedSubFolder != null)
                {
                    _sharedItemRepository.Delete(sharedSubFolder.SharedItemId);
                    StopSharingFolderContents(subFolder, userId);
                }
            }

            foreach (var file in folder.Items.OfType<Files>())
            {
                var sharedFile = _sharedItemRepository.GetByNameAndUserId(file.Name, userId);

                if (sharedFile != null)
                    _sharedItemRepository.Delete(sharedFile.SharedItemId);
            }
        }
    }
}
