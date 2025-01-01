using DumpDrive.Presentation.Extensions;
using DumpDrive.Presentation.Factories;

class Program
{
    static void Main(string[] args)
    {
        var mainMenuActions = MainMenuFactory.CreateActions();
        Console.WriteLine("Welcome to DumpDrive!\n");
        mainMenuActions.PrintActionsAndOpen();
    }
}
