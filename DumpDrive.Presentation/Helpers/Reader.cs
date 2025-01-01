using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using DumpDrive.Data.Enums;

namespace DumpDrive.Presentation.Helpers
{
    public class Reader
    {
        private static readonly Regex regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");

        public static bool TryReadNumber(out int number)
        {
            number = 0;
            var isNumber = int.TryParse(Console.ReadLine(), out var inputNumber);
            if (!isNumber)
                return false;

            number = inputNumber;
            return true;
        }

        public static bool TryReadNumber(string message, out int number)
        {
            Console.WriteLine(message);
            return TryReadNumber(out number);
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

        public static void ReadInput(string message, out string input)
        {
            Console.WriteLine(message);
            input = Console.ReadLine() ?? string.Empty;
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
            Console.WriteLine(message);

            password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.Clear();
                Console.WriteLine("Password cannot be empty.");
                return false;
            }

            if (password.Length < 6)
            {
                Console.Clear();
                Console.WriteLine("Password must be at least 6 characters long.\n");
                return false;
            }

            if (!password.Any(char.IsLower) || !password.Any(char.IsDigit))
            {
                Console.Clear();
                Console.WriteLine("Password must contain at least one lowercase letter and one number\n");
                return false;
            }

            return true;
        }
    }

}
