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

            Console.WriteLine("Email is not in the right format.");
            return false;
        }

        public static bool TryReadPassword(string massage, out string password)
        {
            password = string.Empty;
            Console.WriteLine(massage);

            var passBuilder = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && passBuilder.Length > 0)
                {
                    passBuilder.Remove(passBuilder.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    passBuilder.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            password = passBuilder.ToString();

            return !string.IsNullOrWhiteSpace(password);
        }

    }

}
