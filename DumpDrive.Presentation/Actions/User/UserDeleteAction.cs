using DumpDrive.Domain.Enums;
using DumpDrive.Domain.Repositories;
using DumpDrive.Presentation.Abstractions;
using DumpDrive.Presentation.Helpers;

namespace DumpDrive.Presentation.Actions.User;

public class UserDeleteAction : IAction
{
    private readonly UserRepository _userRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Delete user";

    public UserDeleteAction(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Open()
    {
        var users = _userRepository.GetAll();
        Writer.Write(users);

        Console.WriteLine("\nType user id you want to delete or exit");
        var isRead = Reader.TryReadNumber(out var userId);
        if (!isRead)
        {
            Writer.Error("Error: Not a number\n");
            return;
        }

        var responseResult = _userRepository.Delete(userId);

        switch (responseResult)
        {
            case ResponseResultType.Success:
                Console.WriteLine("User deleted successfully!\n");
                break;
            case ResponseResultType.NotFound:
                Console.WriteLine("User with inputted id does not exist.\n");
                break;
            case ResponseResultType.NoChanges:
                Console.WriteLine("No changes applied\n");
                break;
            default:
                Console.WriteLine("Error occurred while updating user.\n");
                break;
        }

        Console.ReadLine();
        Console.Clear();
    }
}
