using System;
using System.IO;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Digests;

namespace lab1.Crypto
{
    public static class DesPrimitives
    {
        private static CipherMode Mode => CipherMode.CBC;

        public static (byte[] Key, byte[] IV) DeriveNoSalt(string passphrase)
        {
            var md4 = new MD4Digest();
            var bytes = System.Text.Encoding.UTF8.GetBytes(passphrase);
            md4.BlockUpdate(bytes, 0, bytes.Length);
            var hash = new byte[md4.GetDigestSize()];
            md4.DoFinal(hash, 0);

            var key = new byte[8];
            var iv = new byte[8];
            Buffer.BlockCopy(hash, 0, key, 0, 8);
            Buffer.BlockCopy(hash, 8, iv, 0, 8);
            return (key, iv);
        }

        public static byte[] Encrypt(byte[] plain, byte[] key, byte[] iv)
        {
            using var des = DES.Create();
            des.Mode = Mode;
            des.Key = key;
            des.IV = iv;
            des.Padding = PaddingMode.PKCS7;

            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                cs.Write(plain, 0, plain.Length);
            return ms.ToArray();
        }

        public static byte[] Decrypt(byte[] cipher, byte[] key, byte[] iv)
        {
            using var des = DES.Create();
            des.Mode = Mode;
            des.Key = key;
            des.IV = iv;
            des.Padding = PaddingMode.PKCS7;

            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                cs.Write(cipher, 0, cipher.Length);
            return ms.ToArray();
        }
    }
}