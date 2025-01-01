using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Enums;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions.Menus.MyDrive
{
    public class HandleDrive : IAction
    {
        private readonly DriveRepository _driveRepository;
        private readonly SharedRepository _sharedRepository;
        private readonly UserRepository _userRepository;
        int _userId = UserContext.UserId;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Manage Drive Contents\n";

        public HandleDrive(DriveRepository driveRepository, SharedRepository sharedRepository, UserRepository userRepository, int userId)
        {
            _driveRepository = driveRepository;
            _sharedRepository = sharedRepository;
            _userRepository = userRepository;
            _userId = userId;
        }

        private int currentFolderId;

        public void Open()
        {
            Console.Clear();

            var folders = _driveRepository.GetUserFiles(_userId);
            var files = _driveRepository.GetFolderFiles(_userId).OrderByDescending(f => f.LastModified).ToList();

            if (!folders.Any() && !files.Any())
            {
                Writer.Write("No folders found.\n\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Writer.Write("Your Drive Contents:");
            foreach (var folder in folders)
            {
                Writer.Write($"[Folder] {folder.Name}");
            }
            ShowCommands();
        }

        private void ShowCommands()
        {
            var command = Reader.ReadLine("\nEnter a command (or type 'help'): ").Trim().ToLower();
            HandleCommand(command);
        }

        private void HandleCommand(string command)
        {
            switch (command)
            {
                case "help":
                    ShowFolderHelp();
                    break;
                case var cmd when cmd.StartsWith("create folder"):
                    HandleFolderCreation(command);
                    break;
                case var cmd when cmd.StartsWith("create file"):
                    HandleFileCreation(command);
                    break;
                case var cmd when cmd.StartsWith("enter folder"):
                    HandleFolderNavigation(command);
                    break;
                case var cmd when cmd.StartsWith("edit file"):
                    HandleFileEditing(command);
                    break;
                case var cmd when cmd.StartsWith("delete folder") || cmd.StartsWith("delete file"):
                    HandleDeletion(command);
                    break;
                case var cmd when cmd.StartsWith("rename folder") || cmd.StartsWith("rename file"):
                    HandleRenaming(command);
                    break;
                case var cmd when cmd.StartsWith("share"):
                    HandleShareContent(command);
                    break;
                case var cmd when cmd.StartsWith("unshare"):
                    HandleUnshareContent(command);
                    break;
                case "back":
                    return;
                default:
                    Writer.Error("Invalid command.");
                    break;
            }

            Writer.Write("Press any key to continue...");
            Console.ReadKey();
            Open();
        }

        private void ShowFolderHelp()
        {
            Writer.Write("Folder commands:\n" +
                "create folder [folder name] - Create a folder at the current location\n" +
                "enter folder [folder name] - Enter a folder and view its contents\n" +
                "delete folder [name] - Delete a folder\n" +
                "rename folder [name] to [new name] - Rename a folder\n" +
                "share folder [name] with [email] - Share a folder with a user by email\n" +
                "unshare folder [name] with [email] - Stop sharing a folder with a user by email\n" +
                "back - Go back to the previous menu\n");

            var command = Reader.ReadLine("Enter a command: ");
            HandleCommand(command.ToLower());
        }

        private void ShowFileHelp()
        {
            Writer.Write("File commands:\n" +
                "create file [file name] - Create a file in this folder\n" +
                "edit file [file name] - Edit a file\n" +
                "delete file [file name] - Delete a file\n" +
                "rename file [file name] to [new name] - Rename a file\n" +
                "share file [file name] with [email] - Share a file\n" +
                "back - Go back to the previous menu\n");
        }

        private void HandleFolderCreation(string command)
        {
            var folderName = command.Substring("create folder".Length).Trim();
            if (string.IsNullOrWhiteSpace(folderName))
            {
                Writer.Error("Folder name cannot be empty.");
                return;
            }

            var createFolderResult = _driveRepository.CreateFolder(_userId, folderName);
            PrintResult(createFolderResult, "Folder created successfully.", "Failed to create folder.");
        }

        private void HandleFileCreation(string command)
        {
            var fileName = command.Substring("create file".Length).Trim();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Writer.Error("File name cannot be empty.");
                return;
            }

            var createFileResult = _driveRepository.CreateFile(currentFolderId, fileName, _userId);
            PrintResult(createFileResult, "File created successfully.", "Failed to create file.");
        }

        private void HandleFolderNavigation(string command)
        {
            var folderName = command.Substring("enter folder".Length).Trim();
            if (string.IsNullOrWhiteSpace(folderName))
            {
                Writer.Error("Folder name cannot be empty.");
                return;
            }

            var folder = _driveRepository.GetFolderByName(_userId, folderName);
            if (folder == null)
            {
                Writer.Error("Folder not found.");
                return;
            }

            currentFolderId = folder.Id;
            Writer.Write($"\nEntered folder: {folder.Name}");
            bool isInFolder = true;

            while (isInFolder)
            {
                var folderFiles = _driveRepository.GetFolderFiles(folder.Id);
                if (folderFiles.Any())
                {
                    Writer.Write("Files in this folder:");
                    var folderFilesList = folderFiles.ToList();
                    for (int i = 0; i < folderFilesList.Count; i++)
                    {
                        Writer.Write($"\t[File] {folderFilesList[i].Name}");
                    }

                }
                else
                {
                    Writer.Write("\nNo files in this folder.");
                }


                var userCommand = Reader.ReadLine("\nEnter a command (or type 'help'): ").Trim().ToLower();

                if (string.IsNullOrWhiteSpace(userCommand))
                {
                    Writer.Error("You must type in a proper command.");
                    continue;
                }
                if (userCommand.Equals("help", StringComparison.OrdinalIgnoreCase))
                {
                    ShowFileHelp();
                    continue;
                }

                if (userCommand.StartsWith("create file", StringComparison.OrdinalIgnoreCase))
                {
                    HandleFileCreation(userCommand);
                }
                else if (userCommand.StartsWith("edit file", StringComparison.OrdinalIgnoreCase))
                {
                    HandleFileEditing(userCommand);
                }
                else if (userCommand.StartsWith("delete file", StringComparison.OrdinalIgnoreCase))
                {
                    HandleDeletion(userCommand);
                }
                else if (userCommand.StartsWith("rename file", StringComparison.OrdinalIgnoreCase))
                {
                    HandleRenaming(userCommand);
                }
                else if (userCommand.StartsWith("share file", StringComparison.OrdinalIgnoreCase))
                {
                    HandleShareContent(userCommand);
                }
                else if (userCommand.Equals("back", StringComparison.OrdinalIgnoreCase))
                {
                    Writer.Write("Exiting folder...");
                    isInFolder = false;
                }
                else
                {
                    Writer.Error("Invalid command inside a folder.");
                }
            }
        }

        private void HandleRenaming(string command)
        {
            var parts = command.Split(new[] { "to" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                Writer.Error("Invalid rename command. Correct format: rename folder/file 'old name' to 'new name'.");
                return;
            }

            var oldNamePart = parts[0].Trim();

            var oldName = oldNamePart.Replace("rename folder", "").Replace("rename file", "").Trim();
            var newName = parts[1].Trim();

            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                Writer.Error("Both old and new names must be provided.");
                return;
            }

            if (command.StartsWith("rename folder"))
            {
                var renameFolderResult = _driveRepository.RenameFolder(_userId, oldName, newName);
                PrintResult(renameFolderResult, "Folder renamed successfully.", "Failed to rename folder.");
            }
            else if (command.StartsWith("rename file"))
            {
                var renameFileResult = _driveRepository.RenameFile(_userId, oldName, newName);
                PrintResult(renameFileResult, "File renamed successfully.", "Failed to rename file.");
            }
        }

        private void HandleFileEditing(string command)
        {
            var fileName = command.Substring("edit file".Length).Trim();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Writer.Error("File name cannot be empty.");
                return;
            }

            var file = _driveRepository.GetFileByName(_userId, fileName);
            if (file == null)
            {
                Writer.Error("File not found.");
                return;
            }

            Writer.Write($"Editing file: {file.Name}");
            List<string> fileContent = file.Content
                .Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

            bool isEditing = true;
            int currentLineIndex = fileContent.Count;

            while (isEditing)
            {
                Writer.Write("\nFile Content:");
                for (int i = 0; i < fileContent.Count; i++)
                {
                    Writer.Write($"{i + 1}: {fileContent[i]}");
                }

                Writer.Write("\nType in a new line, or press Backspace to delete one (':help' for commands):");

                var input = Reader.ReadInputWithBackspace();

                if (input.isBackspace)
                {
                    if (currentLineIndex > 0)
                    {
                        currentLineIndex--;
                        Writer.Write($"Deleted line {currentLineIndex + 1}: {fileContent[currentLineIndex]}");
                        fileContent.RemoveAt(currentLineIndex);
                    }
                    else
                    {
                        Writer.Error("No lines to delete.");
                    }
                }
                else if (string.IsNullOrWhiteSpace(input.line))
                {
                    Writer.Error("Invalid input.");
                    continue;
                }
                else if (input.line.StartsWith(":"))
                {
                    HandleFileEditingCommand(input.line, ref isEditing, fileContent, file);
                }
                else
                {
                    if (currentLineIndex < fileContent.Count)
                    {
                        fileContent[currentLineIndex] = input.line;
                    }
                    else
                    {
                        fileContent.Add(input.line);
                    }
                    Writer.Write("Line added/updated.");
                    currentLineIndex++;
                }
            }
        }

        private void HandleFileEditingCommand(string input, ref bool isEditing, List<string> fileContent, DFile file)
        {
            switch (input.ToLower())
            {
                case ":help":
                    Writer.Write("Editing commands:\n" +
                        ":help - Show all commands\n" +
                        ":save - Save changes and exit\n" +
                        ":exit - Exit without saving\n");
                    break;
                case ":save":
                    var contentToSave = string.Join("\n", fileContent);
                    var saveResult = _driveRepository.UpdateFileContent(file.Id, contentToSave);
                    if (saveResult == ResponseResultType.Success)
                    {
                        Writer.Write("File saved successfully.");
                    }
                    else
                    {
                        Writer.Error("Failed to save the file.");
                    }
                    isEditing = false;
                    break;
                case ":exit":
                    Writer.Write("Exiting without saving...");
                    isEditing = false;
                    break;
                default:
                    fileContent.Add(input);
                    Writer.Write("Content added to the file.");
                    break;
            }
        }

        private void HandleDeletion(string command)
        {
            var isFolder = command.StartsWith("delete folder");

            var name = isFolder
                ? command.Substring("delete folder".Length).Trim()
                : command.Substring("delete file".Length).Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Writer.Error("Name cannot be empty.");
                return;
            }

            if (isFolder)
            {
                var deleteFolderResult = _driveRepository.DeleteFolder(_userId, name);
                PrintResult(deleteFolderResult, "Folder deleted successfully.", "Failed to delete folder.");
            }
            else
            {
                var deleteFileResult = _driveRepository.DeleteFile(_userId, name);
                PrintResult(deleteFileResult, "File deleted successfully.", "Failed to delete file.");
            }
        }

        private void HandleShareContent(string command)
        {
            var parts = command.Split(new[] { "with" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                Writer.Error("Invalid share command. Correct format: share folder/file 'name' with 'email'.");
                return;
            }
            var contentPart = parts[0].Trim();
            var contentName = contentPart.Replace("share folder", "").Replace("share file", "").Trim();
            var email = parts[1].Trim();

            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                Writer.Error("User not found.");
                return;
            }

            if (command.StartsWith("share folder"))
            {
                var folder = _driveRepository.GetFolderByName(_userId, contentName);
                if (folder == null)
                {
                    Writer.Error("Folder not found.");
                    return;
                }
                var result = _sharedRepository.AddFolderShare(folder.Id, user.Id);
                PrintResult(result, "Folder shared successfully.", "Failed to share folder.");
            }
            else if (command.StartsWith("share file"))
            {
                var file = _driveRepository.GetFileByName(_userId, contentName);
                if (file == null)
                {
                    Writer.Error("File not found.");
                    return;
                }
                var result = _sharedRepository.AddFileShare(file.Id, user.Id);
                PrintResult(result, "File shared successfully.", "Failed to share file.");
            }
        }

        private void HandleUnshareContent(string command)
        {
            var parts = command.Split(new[] { "with" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                Writer.Error("Invalid unshare command. Correct format: unshare folder/file 'name' with 'email'.");
                return;
            }
            var contentPart = parts[0].Trim();
            var contentName = contentPart.Replace("unshare folder", "").Replace("unshare file", "").Trim();
            var email = parts[1].Trim();

            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                Writer.Error("User not found.");
                return;
            }

            if (command.StartsWith("unshare folder"))
            {
                var folder = _driveRepository.GetFolderByName(_userId, contentName);
                if (folder == null)
                {
                    Writer.Error("Folder not found.");
                    return;
                }
                var result = _sharedRepository.RemoveFolderShare(folder.Id, user.Id);
                PrintResult(result, "Folder unshared successfully.", "Failed to unshare folder.");
            }
            else if (command.StartsWith("unshare file"))
            {
                var file = _driveRepository.GetFileByName(_userId, contentName);
                if (file == null)
                {
                    Writer.Error("File not found.");
                    return;
                }
                var result = _sharedRepository.RemoveFileShare(file.Id, user.Id);
                PrintResult(result, "File unshared successfully.", "Failed to unshare file.");
            }
        }

        private void PrintResult(ResponseResultType result, string successMessage, string failureMessage)
        {
            if (result == ResponseResultType.Success)
                Writer.Write(successMessage);
            else
                Writer.Error(failureMessage);
        }
    }
}
