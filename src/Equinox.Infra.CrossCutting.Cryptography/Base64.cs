using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Infra.CrossCutting.Cryptography
{
    public class Base64
    {
        public static string Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
