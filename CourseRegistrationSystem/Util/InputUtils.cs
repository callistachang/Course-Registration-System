using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem
{
    public class InputUtils
    {
        public static bool ReadEnumChoice<T>(out T value)
        {
            value = default;
            var enums = Enum.GetValues(typeof(T));
            for (int i = 0; i < enums.Length; i++)
            {
                Console.WriteLine("({0}) {1}", i + 1, enums.GetValue(i));
            }

            Console.Write("Choose option: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice <= enums.Length)
            {
                value = (T)enums.GetValue(choice - 1);
            }
            return value != null;
        }

        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (!char.IsControl(key.KeyChar) && password.Length < 20)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.Write(Environment.NewLine);
            return password;
        }
    }
}
