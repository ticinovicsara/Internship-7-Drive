using DumpDrive.Domain.Enums;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Menus
{
    public class SharedWithMenu : IAction
    {
        private readonly SharedRepository _sharedRepository;
        private readonly int _userId;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Shared With Me\n";

        public SharedWithMenu(SharedRepository sharedRepository, int userId)
        {
            _sharedRepository = sharedRepository;
            _userId = userId;
        }

        public void Open()
        {
            Console.Clear();

            var sharedFolders = _sharedRepository.GetSharedFolders(_userId);
            var sharedFiles = _sharedRepository.GetSharedFiles(_userId);

            if (!sharedFolders.Any() && !sharedFiles.Any())
            {
                Writer.Write("No shared content found.\n\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Writer.Write("Shared Folders:");
            foreach (var folder in sharedFolders)
            {
                Writer.Write($"[Folder] {folder.Name}");

                var filesInFolder = _sharedRepository.GetSharedFilesInFolder(folder.Id, _userId);
                foreach (var file in filesInFolder)
                {
                    Writer.Write($"  - [File] {file.Name}");
                }
            }

            ShowCommands();
        }

        private void ShowCommands()
        {
            Writer.Write("\nCommands:" +
                "\n1. Comment on File" +
                "\n2. View File Comments" +
                "\n3. Exit to Main Menu");

            var command = Reader.ReadNumber("\nEnter a command: ");
            HandleCommand(command);
        }

        private void HandleCommand(int command)
        {
            switch (command)
            {
                case 1:
                    Comment();
                    break;
                case 2:
                    ViewComments();
                    break;
                case 3:
                    return;
                default:
                    Writer.Error("Invalid command.");
                    break;
            }
            Writer.Write("Press any key to continue...");
            Console.ReadKey();
            Open();
        }

        private void Comment()
        {
            var fileId = Reader.ReadNumber("Enter the ID of the file to comment on: ");
            var content = Reader.ReadLine("Enter your comment: ");

            var result = _sharedRepository.AddComment(fileId, _userId, content);

            if (result == ResponseResultType.Success)
                Writer.Write("Comment added successfully.");
            else Writer.Error("Failed to add comment.");
        }

        private void ViewComments()
        {
            var fileId = Reader.ReadNumber("Enter the ID of the file to view comments: ");
            var comments = _sharedRepository.GetComments(fileId);

            if (!comments.Any())
            {
                Writer.Write("No comments found for this file.");
                return;
            }

            Writer.Write("Comments:");
            foreach (var comment in comments)
                Writer.Write($"[{comment.User?.Name}, {comment.User?.Surname}] {comment.Content} (Posted on: {comment.CreatedAt})");
        }
    }
}
