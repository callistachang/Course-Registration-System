using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseRegistrationSystem
{
    public class Utils
    {
        public static readonly Encoding Encoding = Encoding.UTF8;
        public static readonly TimeSpanToStringConverter TimeSpanConverter = new TimeSpanToStringConverter();
        public static readonly int SaltSize = 32;

        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);
                return BitConverter.ToString(salt).ToLower().Replace("-", "").Substring(0, SaltSize);
            }
        }

        public static string HashPasswordWithSalt(string plaintext, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = Combine(Encoding.GetBytes(plaintext), Encoding.GetBytes(salt));
                return BitConverter.ToString(sha256.ComputeHash(hash)).ToLower().Replace("-", "").Substring(0, SaltSize);
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
