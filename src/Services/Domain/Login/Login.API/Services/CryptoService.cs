using System;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Login.API.Services
{
    public class CryptoService : ICryptoService, IDisposable
    {
        private readonly HashAlgorithm _hashAlgorithm;
        private readonly SymmetricAlgorithm _symmetricAlgorithm;

        public CryptoService(
            SymmetricAlgorithm symmetricAlgorithm,
            HashAlgorithm hashAlgorithm,
            string key)
        {
            _hashAlgorithm = hashAlgorithm;
            _symmetricAlgorithm = ConfigureAlgorithm(
                symmetricAlgorithm, 
                hashAlgorithm, 
                key);
        }

        public string Decrypt(string str)
        {
            using (var transform = _symmetricAlgorithm.CreateDecryptor())
            {
                byte[] cipherBytes = Convert.FromBase64String(str);
                byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                return Encoding.UTF8.GetString(bytes);
            }
        }

        public string Encrypt(string str)
        {
            using (var transform = _symmetricAlgorithm.CreateEncryptor())
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(str);
                byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
        }

        public void Dispose()
        {
            _symmetricAlgorithm?.Dispose();
            _hashAlgorithm?.Dispose();
        }

        private static SymmetricAlgorithm ConfigureAlgorithm(
            SymmetricAlgorithm symmetricAlgorithm, 
            HashAlgorithm hashAlgorithm, 
            string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var keyHash = hashAlgorithm.ComputeHash(keyBytes);

            symmetricAlgorithm.Key = keyHash;
            symmetricAlgorithm.Mode = CipherMode.ECB;
            symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            return symmetricAlgorithm;
        }
    }
}
