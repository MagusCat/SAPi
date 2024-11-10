using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface IEncryptionService
    {
        public string Encrypt(string value);

        public string Decrypt(string valur);
    }
}
