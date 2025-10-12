namespace lab2.Crypto
{
    public class Md5
    {
        private uint[] _state = new uint[4];
        private uint[] _buffer = new uint[16];

        // Константы для раундов MD5
        private static readonly uint[] T =
        {
            0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee,
            0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501,
            0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be,
            0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821,
            0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa,
            0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8,
            0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed,
            0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a,
            0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c,
            0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70,
            0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05,
            0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665,
            0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039,
            0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1,
            0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1,
            0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
        };

        private static readonly int[] S =
        {
            7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,
            5, 9, 14, 20, 5, 9, 14, 20, 5, 9, 14, 20, 5, 9, 14, 20,
            4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23,
            6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21
        };

        public Md5()
        {
            Initialize();
        }

        private void Initialize()
        {
            _state[0] = 0x67452301;
            _state[1] = 0xEFCDAB89;
            _state[2] = 0x98BADCFE;
            _state[3] = 0x10325476;
        }

        public string ComputeFileHash(string filePath)
        {
            return ComputeFileHashWithProgress(filePath, null);
        }

        public string ComputeFileHashWithProgress(string filePath, Action<int>? progressCallback)
        {
            Initialize();

            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileLength = stream.Length;
            var buffer = new byte[64];
            var totalBytes = 0L;
            var lastProgress = -1;

            // Обработка полных блоков
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, 64)) == 64)
            {
                ProcessBlock(buffer);
                totalBytes += bytesRead;
                ReportProgress(totalBytes, fileLength, progressCallback, ref lastProgress);
            }

            // Обработка последнего блока
            ProcessFinalBlock(buffer, bytesRead, fileLength);

            return GetHashString();
        }

        private void ProcessBlock(byte[] block)
        {
            // Преобразование байтов в uint[]
            for (int i = 0; i < 16; i++)
            {
                _buffer[i] = BitConverter.ToUInt32(block, i * 4);
            }

            Transform();
        }

        private void ProcessFinalBlock(byte[] block, int bytesRead, long fileLength)
        {
            var finalBlock = new byte[64];
            Array.Copy(block, 0, finalBlock, 0, bytesRead);

            // Добавляем бит '1'
            finalBlock[bytesRead] = 0x80;

            // Если блок слишком мал для длины, обрабатываем его и создаем новый
            if (bytesRead > 55)
            {
                ProcessBlock(finalBlock);
                Array.Clear(finalBlock, 0, 64);
            }

            // Добавляем длину в битах (little-endian)
            var bitLength = (ulong)(fileLength * 8);
            Buffer.BlockCopy(BitConverter.GetBytes(bitLength), 0, finalBlock, 56, 8);

            ProcessBlock(finalBlock);
        }

        private void Transform()
        {
            var a = _state[0];
            var b = _state[1];
            var c = _state[2];
            var d = _state[3];

            for (var i = 0; i < 64; i++)
            {
                uint f, g;

                if (i < 16)
                {
                    f = (b & c) | (~b & d);
                    g = (uint)i;
                }
                else if (i < 32)
                {
                    f = (d & b) | (~d & c);
                    g = (uint)((5 * i + 1) % 16);
                }
                else if (i < 48)
                {
                    f = b ^ c ^ d;
                    g = (uint)((3 * i + 5) % 16);
                }
                else
                {
                    f = c ^ (b | ~d);
                    g = (uint)((7 * i) % 16);
                }

                var temp = d;
                d = c;
                c = b;
                b += RotateLeft(a + f + T[i] + _buffer[g], S[i]);
                a = temp;
            }

            _state[0] += a;
            _state[1] += b;
            _state[2] += c;
            _state[3] += d;
        }

        private static uint RotateLeft(uint value, int count)
            => (value << count) | (value >> (32 - count));

        private string GetHashString()
        {
            var hashBytes = new byte[16];
            Buffer.BlockCopy(_state, 0, hashBytes, 0, 16);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }

        private static void ReportProgress(long current, long total, Action<int>? callback, ref int lastProgress)
        {
            if (callback == null) return;

            var progress = (int)((current * 100) / total);
            if (progress == lastProgress || progress > 100) return;

            callback(progress);
            lastProgress = progress;
        }
    }
}