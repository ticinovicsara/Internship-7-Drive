using DumpDrive.Data.Entities.Models;

namespace DumpDrive.Presentation.Helpers
{
    internal class Writer
    {
        public static void Write(User user)
        {
            Console.WriteLine($"ID: {user.Id} | Ime: {user.Name} {user.Surname} | Email: {user.Email}");
        }


        public static void Error(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void WriteFolders(ICollection<Folder> folders)
        {
            Console.WriteLine("Mape:");
            foreach (var folder in folders.OrderBy(f => f.Name))
            {
                Console.WriteLine($"- {folder.Name} (Stvorena: {folder.CreatedAt})");
            }
        }

        public static void WriteFiles(ICollection<DFile> files)
        {
            Console.WriteLine("Datoteke:");
            foreach (var file in files.OrderByDescending(f => f.LastModified))
            {
                Console.WriteLine($"- {file.Name} (Zadnja izmjena: {file.LastModified})");
            }
        }

        public static string CaptchaGenerator()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
