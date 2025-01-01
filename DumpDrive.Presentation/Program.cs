using DumpDrive.Data.Entities;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Actions;
using DumpDrive.Presentation.Factories;
using Microsoft.EntityFrameworkCore;


class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DumpDriveDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DumpDrive")));

        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<FileRepository>();
        builder.Services.AddScoped<BaseRepository>();
        builder.Services.AddScoped<FolderRepository>();

        builder.Services.AddScoped<MyDiskAction>();
        builder.Services.AddScoped<LoginAction>();
        builder.Services.AddScoped<RegisterAction>();
        builder.Services.AddScoped<SharedWithMeAction>();

        builder.Services.AddSingleton<MainMenuFactory>();
        builder.Services.AddSingleton<StartMenuFactory>();


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var startMenuFactory = services.GetRequiredService<StartMenuFactory>();

            var startMenu = startMenuFactory.Create();
            Application.SetMenu(startMenu);

            Console.WriteLine("Welcome to DumpDrive!");
            Application.DisplayMenu();

        }
    }
}
