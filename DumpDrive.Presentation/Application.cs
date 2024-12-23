using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Extensions;

public static class Application
{
    private static IList<IAction> _currentMenu;

    public static void SetMenu(IList<IAction> menu)
    {
        _currentMenu = menu;
    }

    public static void DisplayMenu()
    {
        _currentMenu.PrintActionsAndOpen();
    }
}
