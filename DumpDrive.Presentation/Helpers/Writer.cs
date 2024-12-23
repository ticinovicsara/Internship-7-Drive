using DumpDrive.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void WriteFiles(ICollection<File> files)
        {
            Console.WriteLine("Datoteke:");
            foreach (var file in files.OrderByDescending(f => f.LastModified))
            {
                Console.WriteLine($"- {file.Name} ({file.Size} KB, Zadnja izmjena: {file.LastModified})");
            }
        }
    }
}
