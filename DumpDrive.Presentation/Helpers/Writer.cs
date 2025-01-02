using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;

namespace DumpDrive.Presentation.Helpers
{
    public class Writer
    {
        public static void Write(string output)
        {
            Console.WriteLine(output);
        }

        public static void Error(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }

        public static string CaptchaGenerator()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void PrintCommands()
        {
            Console.WriteLine("\nclear                                       - Clear terminal");
            Console.WriteLine("help                                        - Display all commands");
            Console.WriteLine("make folder 'folder name'                   - Create a folder with the specified name");
            Console.WriteLine("make file 'filename'                        - Create a file with the specified name");
            Console.WriteLine("cd 'folder name'                            - Navigate into the specified folder");
            Console.WriteLine("edit file 'filename'                        - Edit the specified file");
            Console.WriteLine("delete folder/file 'folder/file name'       - Delete the specified folder or file");
            Console.WriteLine("change name folder/file 'name' in 'new'     - Rename a folder or file");
            Console.WriteLine("share folder/file with 'email'              - Share a folder or file");
            Console.WriteLine("stop sharing 'folder/file' with 'email'     - Stop shsaring a folder or file");
            Console.WriteLine("back                                        - Return to the previous folder");
        }

        public static void PrintCommentCommands()
        {
            Console.WriteLine("\nhelp                           - Display all commands");
            Console.WriteLine("add comment");
            Console.WriteLine("edit comment");
            Console.WriteLine("delete comment\n");
        }

        public static void PrintComments(List<Comment> comments, UserRepository userRepository)
        {
            Write("Comments:");

            foreach (var comment in comments)
            {
                var userEmail = userRepository.GetById(comment.UserId)?.Email;

                Console.WriteLine($"{comment.CommentId} - {userEmail} - {comment.CreatedAt}");
                Console.WriteLine($"{comment.Content}\n");
            }
        }

        public static void PrintFolders(List<Folder> folders)
        {
            var sortedFolders = folders.OrderBy(f => f.Name).ToList();

            Write("Folders:");

            foreach (var folder in sortedFolders)
                Console.WriteLine($"{folder.Name}/");
        }

        public static void PrintFiles(List<Files> files)
        {
            var sortedFiles = files.OrderByDescending(f => f.LastChangedAt ?? f.CreatedAt).ToList();

            Write("Files:");

            foreach (var file in sortedFiles)
            {
                var lastChanged = file.LastChangedAt ?? file.CreatedAt;
                Console.WriteLine($"{file.Name} (Last Changed: {lastChanged:yyyy-MM-dd HH:mm:ss})");
            }
        }


        public static void PrintSharedContent(List<Item> items)
        {
            Console.Clear();
            Write("Shared With Me:\n");

            List<Folder> folders = new List<Folder>();
            List<Files> files = new List<Files>();

            foreach (var item in items)
            {
                if (item is Folder folder)
                    folders.Add(folder);
                else if (item is Files file)
                    files.Add(file);
            }

            PrintFolders(folders);
            Console.WriteLine("");
            PrintFiles(files);
        }

        public static void PrintReducedCommands()
        {
            Console.WriteLine("\nhelp                              - Display all commands");
            Console.WriteLine("edit file 'filename'               - Edit the specified file");
            Console.WriteLine("delete 'name of folder/file'       - Delete the specified folder or file\n");
        }

        public static void PrintFileEditCommands()
        {
            Console.WriteLine("\n:save               - Save and exit");
            Console.WriteLine(":cancel              - Exit without saving");
            Console.WriteLine(":open comments       - Open comments");
            Console.WriteLine(":help                - Display available commands");
        }


        public static void PrintFileContents(List<string> lines)
        {
            Console.Clear();
            Write("\t- Edit file -\n");

            foreach (var line in lines)
            {
                string input = Console.ReadLine();
                Console.WriteLine("> " + line);
                if (string.IsNullOrWhiteSpace(input) || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }

        public static void PrintCurrentFolderContent(CurrentFolder? currentFolder, List<Folder> folders, List<Files> files)
        {
            Console.Clear();
            Write("\t- My Drive -");

            var location = currentFolder?.Folder?.Name ?? "Root";
            Write(location);

            PrintFolders(folders);
            Console.WriteLine("");
            PrintFiles(files);
        }
    }
}
