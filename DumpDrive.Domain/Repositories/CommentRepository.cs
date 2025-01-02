using DumpDrive.Data.Entities;
using DumpDrive.Domain.Enums;
using DumpDrive.Data.Entities.Models;

namespace DumpDrive.Domain.Repositories
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(DumpDriveDbContext DbContext) : base(DbContext)
        {
        }

        public ResponseResultType Add(Comment comment)
        {
            DbContext.Comments.Add(comment);

            return SaveChanges();
        }

        public ResponseResultType Update(Comment comment, int commentId)
        {
            var commentToUpdate = DbContext.Comments.Find(commentId);

            if (commentToUpdate == null)
                return ResponseResultType.NotFound;

            commentToUpdate.Content = comment.Content;

            return SaveChanges();
        }

        public ResponseResultType Delete(int commentId) {
            var commentToDelete = DbContext.Comments.Find(commentId);

            if (commentToDelete == null)
                return ResponseResultType.NotFound;

            DbContext.Comments.Remove(commentToDelete);

            return SaveChanges();
        }
        public List<Comment> GetAll(int itemId) => DbContext.Comments.Where(c => c.ItemId == itemId).ToList();

        public Comment? GetByIdAndItemId(int commentId, int itemId) => DbContext.Comments.FirstOrDefault(c => c.CommentId == commentId && c.ItemId == itemId);
    }
}
