using DumpDrive.Presentation.Abstractions;

namespace DumpDrive.Presentation.Actions
{
    public class ExitMenuAction : IAction
    {
        public string Name { get; set; } = "Exit";

        public ExitMenuAction()
        {
        }

        public void Open()
        {
            Console.WriteLine("Exiting...");
            Thread.Sleep(500);
        }
    }
}
