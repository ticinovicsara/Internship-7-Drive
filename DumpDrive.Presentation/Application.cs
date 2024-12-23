using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Extensions;

public static class Application
{
    private static IList<IAction> currentMenu;

    public static void SetMenu(IList<IAction> menu)
    {
        currentMenu = menu;
    }

    public static void DisplayMenu()
    {
        currentMenu.PrintActionsAndOpen();
    }
}
