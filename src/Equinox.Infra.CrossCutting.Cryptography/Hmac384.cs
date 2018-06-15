using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Equinox.Infra.CrossCutting.Cryptography
{
    public class Hmac384
    {
        public static string Create(string plaintext, string salt)
        {
            string result = "";
            var enc = Encoding.Default;
            byte[]
            baText2BeHashed = enc.GetBytes(plaintext),
            baSalt = enc.GetBytes(salt);
            HMACSHA384 hasher = new HMACSHA384(baSalt);
            byte[] baHashedText = hasher.ComputeHash(baText2BeHashed);
            result = string.Join("", baHashedText.ToList().Select(b => b.ToString("x2")).ToArray());
            return result;
        }
    }
}
