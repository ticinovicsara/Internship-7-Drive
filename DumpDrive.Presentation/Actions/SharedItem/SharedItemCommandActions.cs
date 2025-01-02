using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Helpers;
using DumpDrive.Domain.Enums;

namespace DumpDrive.Presentation.Actions
{
    public class SharedItemCommandActions
    {
        private readonly SharedItemRepository _sharedItemRepository;

        private readonly ItemRepository _itemRepository;

        private readonly DriveSharingActions _diskSharingActions;

        private readonly User _user;

        public SharedItemCommandActions(SharedItemRepository sharedItemRepository, ItemRepository itemRepository, User user, DriveSharingActions diskSharingActions)
        {
            _sharedItemRepository = sharedItemRepository;
            _itemRepository = itemRepository;
            _user = user;
            _diskSharingActions = diskSharingActions;
        }
        public void DeleteSharedItem(string command)
        {
            var itemName = command.Substring("izbrisi".Length).Trim();

            var sharedItem = _diskSharingActions.GetSharedItem(itemName, _user.Id);
            if (sharedItem == null) return;

            var fullSharedItem = _itemRepository.GetByItemId(sharedItem.ItemId);

            if (fullSharedItem is Folder folder)
                _diskSharingActions.StopSharingFolderContents(folder, _user.Id);
           
            var result = _sharedItemRepository.Delete(sharedItem.SharedItemId);

            if (result != ResponseResultType.Success)
            {
                Writer.Error("Failed to delete an item.\n");
                Reader.PressAnyKey();
                return;
            }

            DisplayAllSharedItems();
        }

        public void DisplayAllSharedItems()
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
    }
}
