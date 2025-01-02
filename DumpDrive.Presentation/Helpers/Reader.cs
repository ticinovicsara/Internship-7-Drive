using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using DumpDrive.Data.Entities.Models;
using DumpDrive.Domain.Repositories;

namespace DumpDrive.Presentation.Helpers
{
    public class Reader
    {
        private static readonly Regex regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");

        public static void TryReadInput(string message, out string input)
        {
            do
            {
                Console.Write($"{message}: ");
                input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                    Writer.Error("Input cannot be empty. Please try again.\n");

            } while (string.IsNullOrEmpty(input));
        }

        public static bool TryReadNumber(out int number)
        {
            number = 0;
            var isNumber = int.TryParse(Console.ReadLine(), out var inputNumber);
            if (!isNumber)
                return false;

            number = inputNumber;
            return true;
        }


        public static bool TryReadLine(string message, out string line)
        {
            line = string.Empty;

            Console.WriteLine(message);
            var input = Console.ReadLine();
            var isEmpty = string.IsNullOrWhiteSpace(input);

            if (!isEmpty)
                line = input;

            return !isEmpty;
        }


        public static bool TryReadEmail(string message, out string email)
        {
            email = string.Empty;
            Console.WriteLine(message);

            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (regex.IsMatch(input))
            {
                email = input;
                return true;
            }

            Console.Clear();
            Console.WriteLine("Email is not in the right format.");
            return false;
        }

        public static bool TryReadPassword(string message, out string password)
        {
            password = string.Empty;
            Console.Write($"{message}: ");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Writer.Error("Password cannot be empty. Please try again.\n");
                return false;
            }

            if (input.Length < 6)
            {
                Writer.Error("Password must be at least 6 characters long. Please try again.\n");
                return false;
            }

            if (!input.Any(char.IsLower) || !input.Any(char.IsDigit))
            {
                Writer.Error("Password must contain at least one lowercase letter and one number. Please try again.\n");
                return false;
            }

            password = input;
            return true;
        }


        public static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
        }

        public static bool IsEmailAlreadyInUse(string email, UserRepository userRepository)
        {
            var user = userRepository.GetByEmail(email);

            if (user is not null)
            {
                Writer.Error("Email is already in use. Please try again.\n");
                return true;
            }

            return false;
        }

        public static bool IsCommand(string input, string expectedCommand)
        {
            return input.Equals(expectedCommand, StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckIfNameAlreadyExists(string name, List<Folder> folders, List<Files> files)
        {
            if (folders.Any(i => i.Name == name) || files.Any(i => i.Name == name))
            {
                Writer.Error($"Name {name} already exists in this location\n");
                return true;
            }

            return false;
        }

        public static bool StartsWithCommand(string input, string prefix)
        {
            return input.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
        }

        public static void TryReadCommand(Dictionary<Func<string, bool>, Action<string>> commandDictionary)
        {
            while (true)
            {
                TryReadInput("Enter a command ('help' to see all commands, 'exit' to quit navigation)", out var command);
                command = command.Trim();

                if (IsCommand(command, "exit"))
                    break;

                var matchedCommand = commandDictionary.Keys.FirstOrDefault(predicate => predicate(command));

                if (matchedCommand != null)
                {
                    commandDictionary[matchedCommand](command);
                }
                else
                {
                    Writer.Error("Invalid command. Try again.\n");
                }
            }
        }

        public static bool PasswordCheck(string message, string userPassword)
        {
            if (TryReadPassword(message, out var enteredPassword))
            {
                if (enteredPassword != userPassword)
                {
                    Writer.Error("Password is incorrect. Please try again.");
                    PressAnyKey();
                    return false;
                }

                return true;
            }

            return false;
        }

        public static string ConfirmPassword(string message)
        {
            string password;

            while (!TryReadPassword(message, out password))
            {
                Writer.Error("Invalid password. Please try again.\n");
            }

            while (true)
            {
                if (TryReadPassword("Confirm your password", out string confirmPassword))
                {
                    if (password == confirmPassword)
                        return password;

                    Writer.Error("Passwords do not match. Please try again.\n");
                }
            }
        }

        public static (string?, string?) ParseShareCommand(string command, int expectedParts, int firstPart, int secondPart)
        {
            var commandParts = command.Split(" ");

            if (!CheckShareCommand(commandParts.Length, expectedParts))
                return (null, null);

            return (commandParts[firstPart], commandParts[secondPart]);
        }

        public static bool CheckShareCommand(int commandPartsLength, int length)
        {
            if (commandPartsLength < length)
            {
                Writer.Error("Invalid command. Try again.\n");
                return false;
            }
            return true;
        }


        public static bool IsAlreadyShared(string itemName, int userId, SharedItemRepository sharedItemRepository)
        {
            var sharedItem = sharedItemRepository.GetByNameAndUserId(itemName, userId);
            if (sharedItem != null)
            {
                Writer.Error($"Item {itemName} is already being shared\n");
                return true;
            }
            return false;
        }

        public static bool ConfirmAction(string message)
        {
            TryReadInput($"\n{message} (y/n)", out var input);

            while (input != "n" && input != "y")
            {
                Writer.Write("Enter n or y");
                TryReadInput($"\n{message} (y/n)", out input);
            }
            Console.Write("\n");

            return input == "y";
        }

    }

}
