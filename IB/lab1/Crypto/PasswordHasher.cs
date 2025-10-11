using System.Text;
using Org.BouncyCastle.Crypto.Digests;

namespace lab1.Crypto
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return ComputeMd4(password);
        }

        private static string ToHex(byte[] bytes)
        {
            var c = new char[bytes.Length * 2];
            int i = 0;
            foreach (var b in bytes)
            {
                c[i++] = GetHexNibble(b >> 4);
                c[i++] = GetHexNibble(b & 0xF);
            }
            return new string(c);

            static char GetHexNibble(int v) => (char)(v < 10 ? ('0' + v) : ('A' + (v - 10)));
        }

        private static string ComputeMd4(string s)
        {
            var md4 = new MD4Digest();
            var bytes = Encoding.UTF8.GetBytes(s);
            md4.BlockUpdate(bytes, 0, bytes.Length);
            var hash = new byte[md4.GetDigestSize()];
            md4.DoFinal(hash, 0);
            return ToHex(hash);
        }
    }
}