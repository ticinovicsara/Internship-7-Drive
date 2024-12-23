using DumpDrive.Presentation.Factories;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to DumpDrive!");

        Application.SetMenu(StartMenuFactory.Create());
        while (true)
        {
            Application.DisplayMenu();
        }
    }
}
