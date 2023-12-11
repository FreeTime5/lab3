using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Services.HmacGenerator.Implementaions;

public class HmacGenerator : IHmacGenerator
{
    public string GenerateHmac(string move)
    {
        byte[] key = RandomNumberGenerator.GetBytes(64);
        var hmacGenerator = new HMACSHA256() { Key = key };
        return Convert.ToHexString(hmacGenerator.ComputeHash(Encoding.UTF8.GetBytes(move)));
    }
}
