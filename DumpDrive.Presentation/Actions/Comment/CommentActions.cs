using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions
{
    public class CommentActions
    {
        private readonly User _user;

        private readonly UserRepository _userRepository;

        private readonly CommentRepository _commentRepository;

        private readonly int _itemId;
        public CommentActions(UserRepository userRepository,CommentRepository commentRepository, int itemId, User user)
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _itemId = itemId;
            _user = user;
        }

        public void Open()
        {
            var commentCommandActions = new CommentCommandActions(_userRepository, _commentRepository, _itemId, _user);
            commentCommandActions.OpenComments();

            var commandDictionary = new Dictionary<Func<string, bool>, Action<string>>
            {
                { command => Reader.IsCommand(command, "help"), _=> Writer.PrintCommentCommands() },

                { command => Reader.IsCommand(command, "dodaj komentar"), _ => commentCommandActions.AddComment() },

                { command => Reader.IsCommand(command, "uredi komentar"), _=> commentCommandActions.EditComment() },

                { command => Reader.IsCommand(command, "izbrisi komentar"), _=> commentCommandActions.DeleteComment() }
            };

            Reader.TryReadCommand(commandDictionary);
        }
    }
}
