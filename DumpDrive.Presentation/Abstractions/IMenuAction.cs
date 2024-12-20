namespace DumpDrive.Domain.Abstractions
{
    public interface IMenuAction : IAction
    {
        IList<IAction> Actions { get; set; }
    }
}
