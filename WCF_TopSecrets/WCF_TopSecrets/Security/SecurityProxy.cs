using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WCF_TopSecrets.Security
{
    class SecurityProxy
    {
        string ivStr = "xXgNUHMPWfy2x3WK";

        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string Encrypt(string userKey, string data)
        {
            return data;
            byte[] iv = Encoding.UTF8.GetBytes(ivStr);
            string keyTmp = Convert.ToBase64String(GetHash(userKey)).Substring(0, 32);
            byte[] key = Encoding.UTF8.GetBytes(keyTmp);
            byte[] encrypted;


            using (AesManaged aes = new AesManaged())
            {
                // Encrypt string    
                encrypted = EncryptB(data, key, iv);
            }

            return System.Text.Encoding.UTF8.GetString(encrypted);
        }

        public string Decrypt(string userKey, string data)
        {
            return data;
            byte[] iv = Encoding.UTF8.GetBytes(ivStr);
            string keyTmp = Convert.ToBase64String(GetHash(userKey)).Substring(0, 32);
            byte[] key = Encoding.UTF8.GetBytes(keyTmp);
            byte[] encrypted = System.Text.Encoding.UTF8.GetBytes(data);
            string decrypted;

            using (AesManaged aes = new AesManaged())
            {
                decrypted = DecryptS(encrypted, key, iv);
            }

            return decrypted;
        }

        static byte[] EncryptB(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return encrypted;
        }
        static string DecryptS(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}
