using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem
{
    public class Utils
    {
        public static Encoding Encoding = Encoding.UTF8;

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

        public static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[32];
                rng.GetBytes(salt);
                return salt;
            }
        }

        public static byte[] HashPasswordWithSalt(byte[] plaintext, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = Combine(plaintext, salt);
                return sha256.ComputeHash(hash);
            }
        }

        /// <summary>
        /// Combine 2 byte arrays.
        /// </summary>
        private static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] combined = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, combined, 0, first.Length);
            Buffer.BlockCopy(second, 0, combined, first.Length, second.Length);

            return combined;
        }
    }
}
