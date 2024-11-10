using Service.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly byte[] keybyte;

        public EncryptionService(byte[] key)
        {
            keybyte = key;
        }

        public string Decrypt(string value)
        {
            byte[] cryp;

            using var aes = Aes.Create();

            var encryptor = aes.CreateEncryptor(keybyte, aes.IV);

            using (var memory = new MemoryStream())
            {
                using (var stream = new CryptoStream(memory, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(stream)) 
                    {
                        writer.Write(value);    
                    }
                }

                cryp = memory.ToArray();

                return Convert.ToBase64String(aes.IV.Concat(cryp).ToArray());
            }
        }

        public string Encrypt(string value)
        {
            var bytes = Convert.FromBase64String(value);

            var iv = bytes.Take(16).ToArray();
            var cryp = bytes.Skip(16).ToArray();

            using var aes = Aes.Create();

            var decryptor = aes.CreateDecryptor(keybyte, iv);

            using (var memory = new MemoryStream(cryp))
            {
                using (var stream = new CryptoStream(memory, decryptor, CryptoStreamMode.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
