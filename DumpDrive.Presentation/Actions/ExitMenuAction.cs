using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDrive.Domain.Actions
{
    public class ExitMenuAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Exit";

        public ExitMenuAction()
        {
        }

        public void Open()
        {
        }
    }
}
