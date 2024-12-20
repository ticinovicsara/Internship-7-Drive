namespace DumpDrive.Domain.Abstractions
{
    public interface IMenuAction
    {
        IList<IAction> Actions { get; set; }
    }
}
