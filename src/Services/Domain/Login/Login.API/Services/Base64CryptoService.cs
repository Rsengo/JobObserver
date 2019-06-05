using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.API.Services
{
    public class Base64CryptoService : ICryptoService
    {
        public string Decrypt(string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            var str = Encoding.UTF8.GetString(bytes);
            return str;
        }

        public string Encrypt(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }
}
