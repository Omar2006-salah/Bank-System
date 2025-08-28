using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project
{
    public static class CryptoHelper
    {
        // Key must be 32 bytes for AES-256
        private static readonly string key = "12345678901234567890123456789012"; // 32 bytes
                                                                                 // IV must be 16 bytes
        private static readonly string iv = "1234567890123456"; // 16 bytes

        // Encryption function
        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = Encoding.UTF8.GetBytes(iv);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Encryption failed: " + ex.Message, ex);
            }
        }

        // Decryption function
        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = Encoding.UTF8.GetBytes(iv);

                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (FormatException ex)
            {
                throw new CryptographicException("Invalid Base64 string provided for decryption.", ex);
            }
            catch (Exception ex)
            {
                throw new CryptographicException("Decryption failed: " + ex.Message, ex);
            }
        }
    }

}
