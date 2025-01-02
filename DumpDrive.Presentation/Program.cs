using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Factories;
using DumpDrive.Data.Entities;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(config =>
            {
                config.AddConsole();
                config.SetMinimumLevel(LogLevel.Information);
            })
            .AddScoped<UserRepository>()
            .AddScoped<SharedRepository>()
            .AddScoped<DriveRepository>()
            .AddScoped<MainMenuFactory>()
            .AddScoped<StartMenuFactory>()
            .BuildServiceProvider();


        using (serviceProvider)
        {
            try
            {
                var startMenuFactory = serviceProvider.GetRequiredService<StartMenuFactory>();
                startMenuFactory.DisplayStartMenu();
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while running the application.");
            }
        }
    }
}
