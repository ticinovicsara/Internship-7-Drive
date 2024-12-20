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
            => Console.WriteLine($"{user.Id}: {user.Name} {user.Surname}");


        public static void Error(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
