using DumpDrive.Presentation.Factories;
using DumpDrive.Presentation.Extensions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome do DumpDrive!\n\n");

        var action = StartMenuFactory.Create();

        action.PrintActionsAndOpen();
    }
}
