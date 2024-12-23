using DumpDrive.Data.Entities.Models;

namespace DumpDrive.Domain.Repositories
{
    public class FileRepository
    {
        private readonly List<File> files = new();

        public ICollection<File> GetFilesByUser(int userId)
        {
            return files.Where(f => f.OwnerUserId == userId);
        }

        public void AddFile(File file)
        {
            files.Add(file);
        }

        public void DeleteFile(int fileId)
        {
            var file = files.FirstOrDefault(f => f.Id == fileId);
            if (file != null) files.Remove(file);
        }

        public ICollection<File> GetSharedWithUser(int userId)
        {
            return files.Where(f => f.SharedWith.Contains(userId));
        }
    }
}
