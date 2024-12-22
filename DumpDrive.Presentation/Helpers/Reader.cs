using System.Text;
using System.Xml;
using DumpDrive.Data.Enums;

namespace DumpDrive.Presentation.Helpers
{
    internal class Reader
    {
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

        //?????
        //public static bool TryReadStatus(string message, out Status status)
        //{
        //    status = Status.Todo;

        //    Console.WriteLine(message);
        //    var input = Console.ReadLine();
        //    var isStatus = Enum.TryParse(typeof(Status), input, out var inputStatus);

        //    if (isStatus && inputStatus is not null)
        //    {
        //        status = (Status)inputStatus;
        //    }

        //    return isStatus;
        //}

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
            var isEmpty = string.IsNullOrWhiteSpace(input);
            var isValid = !string.IsNullOrWhiteSpace(input) &&
                input.Contains("@") &&
                input.Contains(".") &&
                input.Split("@").Length == 2 &&
                input.Split(".").Last().Length >= 2;

            if (isValid)
                email = input;

            return isValid;
        }

        public static bool TryReadPassword(string massage, out string password)
        {
            password = string.Empty;
            Console.WriteLine(massage);

            ConsoleKey key;
            var passBuilder = StringBuilder();

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
