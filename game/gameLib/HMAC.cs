using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace gameLib
{
    public static class HMAC
    {
        private static KeyGenerator _key = new KeyGenerator();
        public static string CreateHMAC(string name)
        {
            using var hmac = new HMACSHA256();
            hmac.Key = _key.key;
            return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(name)));
        }
    }
}
