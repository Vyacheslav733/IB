using System.Text;

namespace lab3.Crypto
{
    public class DES_CFB
    {
        private const int BlockSize = 8; // 64 бита для DES
        private ulong[] roundKeys;

        // Начальная перестановка (IP)
        private static readonly int[] IP = {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        };

        // Окончательная перестановка (IP−1) (Инверсия IP)
        private static readonly int[] FP = {
            40, 8, 48, 16, 56, 24, 64, 32,
            39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30,
            37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28,
            35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26,
            33, 1, 41, 9, 49, 17, 57, 25
        };

        // Перестановочный выбор 1 (PC-1)
        private static readonly int[] PC1 = {
            57, 49, 41, 33, 25, 17, 9,
            1, 58, 50, 42, 34, 26, 18,
            10, 2, 59, 51, 43, 35, 27,
            19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15,
            7, 62, 54, 46, 38, 30, 22,
            14, 6, 61, 53, 45, 37, 29,
            21, 13, 5, 28, 20, 12, 4
        };

        // Перестановочный выбор 2 (PC-2)
        private static readonly int[] PC2 = {
            14, 17, 11, 24, 1, 5,
            3, 28, 15, 6, 21, 10,
            23, 19, 12, 4, 26, 8,
            16, 7, 27, 20, 13, 2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32
        };

        // Функция расширения (E)
        private static readonly int[] E = {
            32, 1, 2, 3, 4, 5,
            4, 5, 6, 7, 8, 9,
            8, 9, 10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32, 1
        };

        // Перестановка (P)
        private static readonly int[] P = {
            16, 7, 20, 21, 29, 12, 28, 17,
            1, 15, 23, 26, 5, 18, 31, 10,
            2, 8, 24, 14, 32, 27, 3, 9,
            19, 13, 30, 6, 22, 11, 4, 25
        };

        // Блоки замещения (S-блоки)
        private static readonly int[,,] SBoxes = {
            {
                {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
                {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
                {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
                {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}
            },
            {
                {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
                {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
                {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
                {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}
            },
            {
                {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
                {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
                {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
                {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}
            },
            {
                {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
                {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
                {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
                {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}
            },
            {
                {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
                {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
                {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
                {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}
            },
            {
                {12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
                {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
                {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
                {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}
            },
            {
                {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
                {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
                {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
                {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}
            },
            {
                {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
                {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
                {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
                {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}
            }
        };

        // Количество поворотов влево
        private static readonly int[] ShiftBits = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        public DES_CFB()
        {
            roundKeys = new ulong[16];
        }

        public void EncryptFile(string inputFile, string outputFile, byte[] key, byte[] iv,
            Action<int>? progressCallback = null)
        {
            ValidateKey(key);
            GenerateRoundKeys(key);

            using (var input = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (var output = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                var fileLength = input.Length;
                var buffer = new byte[BlockSize];
                var feedback = new byte[BlockSize];
                Array.Copy(iv, feedback, Math.Min(iv.Length, BlockSize));

                long totalBytes = 0;
                int bytesRead;

                while ((bytesRead = input.Read(buffer, 0, BlockSize)) > 0)
                {
                    // Шифруем блок обратной связи
                    byte[] encryptedFeedback = EncryptBlock(feedback);

                    // XOR с открытым текстом
                    for (int i = 0; i < bytesRead; i++)
                    {
                        buffer[i] ^= encryptedFeedback[i];
                    }

                    // Записываем результат
                    output.Write(buffer, 0, bytesRead);

                    // Обновляем обратную связь
                    Array.Copy(buffer, feedback, bytesRead);
                    if (bytesRead < BlockSize)
                    {
                        Array.Clear(feedback, bytesRead, BlockSize - bytesRead);
                    }

                    totalBytes += bytesRead;
                    progressCallback?.Invoke((int)((totalBytes * 100) / fileLength));
                }
            }
        }

        public void DecryptFile(string inputFile, string outputFile, byte[] key, byte[] iv,
            Action<int>? progressCallback = null)
        {
            ValidateKey(key);
            GenerateRoundKeys(key);

            using (var input = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (var output = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                var fileLength = input.Length;
                var buffer = new byte[BlockSize];
                var feedback = new byte[BlockSize];
                Array.Copy(iv, feedback, Math.Min(iv.Length, BlockSize));

                long totalBytes = 0;
                int bytesRead;

                while ((bytesRead = input.Read(buffer, 0, BlockSize)) > 0)
                {
                    // Шифруем блок обратной связи
                    byte[] encryptedFeedback = EncryptBlock(feedback);

                    // Сохраняем шифртекст перед изменением
                    byte[] cipherText = new byte[bytesRead];
                    Array.Copy(buffer, cipherText, bytesRead);

                    // XOR с шифртекстом
                    for (int i = 0; i < bytesRead; i++)
                    {
                        buffer[i] ^= encryptedFeedback[i];
                    }

                    // Записываем расшифрованные данные
                    output.Write(buffer, 0, bytesRead);

                    // Обновляем обратную связь
                    Array.Copy(cipherText, feedback, bytesRead);
                    if (bytesRead < BlockSize)
                    {
                        Array.Clear(feedback, bytesRead, BlockSize - bytesRead);
                    }

                    totalBytes += bytesRead;
                    progressCallback?.Invoke((int)((totalBytes * 100) / fileLength));
                }
            }
        }

        private byte[] EncryptBlock(byte[] block)
        {
            ulong data = BytesToUInt64(block);
            data = InitialPermutation(data);

            uint left = (uint)(data >> 32);
            uint right = (uint)(data & 0xFFFFFFFF);

            // 16 раундов
            for (int i = 0; i < 16; i++)
            {
                uint temp = right;
                right = left ^ Feistel(right, roundKeys[i]);
                left = temp;
            }

            // Окончательный обмен
            data = ((ulong)right << 32) | left;
            data = FinalPermutation(data);

            return UInt64ToBytes(data);
        }

        private uint Feistel(uint right, ulong roundKey)
        {
            // Расширение: 32 бита -> 48 бит
            ulong expanded = Expansion(right);

            // OR с раундовым ключом
            expanded ^= roundKey;

            // Замена S-Box: 48 бит-> 32 бита
            uint substituted = Substitution(expanded);

            // Перестановка
            return Permutation(substituted);
        }

        private ulong Expansion(uint data)
        {
            ulong result = 0;
            for (int i = 0; i < 48; i++)
            {
                int bitPos = 32 - E[i];
                ulong bit = (data >> bitPos) & 0x1;
                result |= (bit << (47 - i));
            }
            return result;
        }

        private uint Substitution(ulong data)
        {
            uint result = 0;
            for (int i = 0; i < 8; i++)
            {
                // Извлечение 6 бит для этого S-Box
                int chunk = (int)((data >> (42 - i * 6)) & 0x3F);

                // Получаем строку и столбец
                int row = ((chunk & 0x20) >> 4) | (chunk & 0x1);
                int col = (chunk >> 1) & 0xF;

                // Получаем значение S-Box
                int sboxValue = SBoxes[i, row, col];

                // Комбинируем результаты
                result |= (uint)(sboxValue << (28 - i * 4));
            }
            return result;
        }

        private uint Permutation(uint data)
        {
            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                int bitPos = 32 - P[i];
                uint bit = (data >> bitPos) & 0x1;
                result |= (bit << (31 - i));
            }
            return result;
        }

        private ulong InitialPermutation(ulong data)
        {
            return Permute(data, IP, 64);
        }

        private ulong FinalPermutation(ulong data)
        {
            return Permute(data, FP, 64);
        }

        private ulong Permute(ulong data, int[] table, int size)
        {
            ulong result = 0;
            for (int i = 0; i < table.Length; i++)
            {
                int bitPos = size - table[i];
                ulong bit = (data >> bitPos) & 0x1;
                result |= (bit << (table.Length - 1 - i));
            }
            return result;
        }

        private void GenerateRoundKeys(byte[] key)
        {
            ulong key64 = BytesToUInt64(key);

            // Перестановка PC1
            ulong permutedKey = Permute(key64, PC1, 64);

            uint left = (uint)(permutedKey >> 28);
            uint right = (uint)(permutedKey & 0xFFFFFFF);

            for (int i = 0; i < 16; i++)
            {
                // Сдвиги влево
                left = LeftShift(left, ShiftBits[i]);
                right = LeftShift(right, ShiftBits[i]);

                // Перестановка PC2
                ulong combined = ((ulong)left << 28) | right;
                roundKeys[i] = Permute(combined, PC2, 56);
            }
        }

        private uint LeftShift(uint data, int shifts)
        {
            return (data << shifts) | (data >> (28 - shifts));
        }

        private ulong BytesToUInt64(byte[] bytes)
        {
            ulong result = 0;
            for (int i = 0; i < 8; i++)
            {
                result |= (ulong)bytes[i] << (56 - i * 8);
            }
            return result;
        }

        private byte[] UInt64ToBytes(ulong value)
        {
            byte[] result = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (byte)(value >> (56 - i * 8));
            }
            return result;
        }

        private void ValidateKey(byte[] key)
        {
            if (key == null || key.Length != 8)
                throw new ArgumentException("Ключ должен быть длиной 8 байт (64 бита)");
        }

        public byte[] GenerateIV()
        {
            var iv = new byte[BlockSize];
            new Random().NextBytes(iv);
            return iv;
        }

        public bool ValidateKeyString(string key)
        {
            if (string.IsNullOrEmpty(key)) return false;

            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                return keyBytes.Length == 8;
            }
            catch
            {
                return false;
            }
        }
    }
}
