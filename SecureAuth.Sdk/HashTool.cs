using System;
using System.Security.Cryptography;
using System.Text;

namespace SecureAuth.Sdk
{
    internal class HashTool
    {
        internal static string SHA256HashToBase64(string key, string value)
        {
            string result = "";
            var keyBytes = HexStringToByteArray(key);
            var valueBytes = Encoding.UTF8.GetBytes(value);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                var hash = hmac.ComputeHash(valueBytes);
                result = Convert.ToBase64String(hash);
            }
            return result;
        }

        internal static string SHA256HashToHex(string key, string value)
        {
            string result = "";
            var keyBytes = HexStringToByteArray(key);
            var valueBytes = Encoding.UTF8.GetBytes(value);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                var hash = hmac.ComputeHash(valueBytes);
                result = BitConverter.ToString(hash).Replace("-", "");
            }
            return result;
        }

        internal static byte[] HexStringToByteArray(String hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}