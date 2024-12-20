using DumpDrive.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DumpDrive.Domain.Actions.User
{
    public class UserAction(IList<IAction> actions) : base(actions)
    {
        Name = "User menu";
    }

    public override void Open()
        {
            Console.WriteLine("Users management");
            base.Open();
        }
    }
