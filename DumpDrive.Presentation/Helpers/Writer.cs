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
            => Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}");
    }
}
