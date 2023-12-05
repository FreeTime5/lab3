using System.Security.Cryptography;

namespace gameLib
{
    internal class KeyGenerator
    {
        internal byte[] key { get; private set; }
        internal KeyGenerator()
        {
            key = RandomNumberGenerator.GetBytes(64);
        }
    }
}
