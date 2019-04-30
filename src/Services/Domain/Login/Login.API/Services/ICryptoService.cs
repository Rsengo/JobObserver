using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.Services
{
    public interface ICryptoService: IDisposable
    {
        string Encrypt(string str);

        string Decrypt(string str);
    }
}
