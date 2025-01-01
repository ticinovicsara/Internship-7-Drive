using DumpDrive.Data.Entities;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DumpDrive"]?.ConnectionString;

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DumpDrive' not found in App.config.");
        }

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration)
            .AddDbContext<DumpDriveDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DumpDrive")))

            .AddScoped<UserRepository>()
            .AddScoped<FileRepository>()
            .AddScoped<FolderRepository>()

            .AddScoped<MyDiskAction>()
            .AddScoped<LoginAction>()
            .AddScoped<RegisterAction>()
            .AddScoped<SharedWithMeAction>()

            .AddSingleton<MainMenuFactory>()
            .AddSingleton<StartMenuFactory>()
            .AddSingleton<DumpDriveDbContextFactory>()

            .BuildServiceProvider();


        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;

            var startMenuFactory = services.GetRequiredService<StartMenuFactory>();
            var startMenu = startMenuFactory.Create();

            Application.SetMenu(startMenu);

            Console.WriteLine("Welcome to DumpDrive!\n");
            Application.DisplayMenu();
        }
    }
}
