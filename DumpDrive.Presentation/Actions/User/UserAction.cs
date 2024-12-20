using DumpDrive.Domain.Abstractions;

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
