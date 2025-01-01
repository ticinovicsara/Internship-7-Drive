using Microsoft.Extensions.DependencyInjection;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Factories;
using DumpDrive.Presentation.Actions;
using DumpDrive.Data.Entities;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<DumpDriveDbContext>()
            .AddScoped<UserRepository>()
            .AddScoped<SharedRepository>()
            .AddScoped<DriveRepository>()
            .AddScoped<MainMenuFactory>()
            .AddScoped<StartMenuFactory>()
            .BuildServiceProvider();

        var startMenuFactory = serviceProvider.GetService<StartMenuFactory>();

        startMenuFactory.DisplayStartMenu();
    }
}
