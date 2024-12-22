using TodoApp.Presentation.Extensions;
using TodoApp.Presentation.Factories;

using DumpDrive.Presentation.Factories;

class Program
{
    static void Main(string[] args)
    {
        var mainMenuActions = MainMenuFactory.CreateActions();
        var mainMenu = new BaseMenuAction(mainMenuActions)
        {
            Name = "Main menu"
        };

        mainMenu.Open();
    }
}
