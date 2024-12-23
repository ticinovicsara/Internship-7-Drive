using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DumpDrive.Presentation.Abstractions;

namespace DumpDrive.Domain.Actions
{
    public class ExitMenuAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Exit";

        public ExitMenuAction()
        {
        }

        public void Open()
        {
            Console.WriteLine("Izlaz iz trenutnog izbornika...");
            Thread.Sleep(500);
        }
    }
}
