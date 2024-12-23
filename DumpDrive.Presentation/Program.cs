using DumpDrive.Presentation.Factories;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to DumpDrive!\n");

        Application.SetMenu(StartMenuFactory.Create());

        while (true)
        {
            Application.DisplayMenu();
        }
    }
}
