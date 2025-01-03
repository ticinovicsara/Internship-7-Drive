using DumpDrive.Data.Entities;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DumpDrive.Domain.Repositories
{
    public class ItemRepository : BaseRepository
    {
        public ItemRepository(DumpDriveDbContext DbContext) : base(DbContext)
        {
        }

        public ResponseResultType Delete(int itemId)
        {
            var itemToDelete = DbContext.Items.Find(itemId);

            if (itemToDelete == null)
                return ResponseResultType.NotFound;

            DbContext.Items.Remove(itemToDelete);

            return SaveChanges();
        }

        public Item? GetByItemId(int itemId) => DbContext.Items.FirstOrDefault(i => i.ItemId == itemId);

        public Item? GetByName(string name, int? parentFolderId, string itemType)
        {
            if (itemType == "folder")
                return DbContext.Folders.FirstOrDefault(f => f.Name == name && f.ParentFolderId == parentFolderId);
            if (itemType == "file")
                return DbContext.Files.FirstOrDefault(f => f.Name == name && f.ParentFolderId == parentFolderId);

            return null;
        }

        public Folder? GetByItemIdWithItems(int folderId)
        {
            return DbContext.Folders
                .Include(f => f.Items)
                .ThenInclude(i => (i as Folder).Items)
                .FirstOrDefault(f => f.ItemId == folderId);
        }
    }
}

