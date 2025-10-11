using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using lab1.Crypto;
using lab1.Domain;
using Microsoft.Data.Sqlite;

namespace lab1.Storage
{
    public sealed class EncryptedSqliteStore : IDisposable
    {
        private const string Magic = "AUTHDB1"; // 7 bytes
        private const string EncryptionKey = "DEFAULT_DB_KEY";

        private readonly string _encryptedPath;
        private readonly string _tempPath;
        private bool _disposed;

        public EncryptedSqliteStore(string encryptedPath)
        {
            _encryptedPath = encryptedPath;
            _tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".sqlite");
        }

        public Database TryLoadOrCreate()
        {
            EnsureNotDisposed();

            if (File.Exists(_encryptedPath))
            {
                try
                {
                    DecryptToTempFile();
                    return LoadFromTempDatabase();
                }
                catch (Exception ex) when (IsDatabaseCorrupted(ex))
                {
                    // Создаем новую базу если текущая повреждена
                    MessageBox.Show("База данных повреждена. Создана новая база.", "Восстановление",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    CreateNewDatabase();
                    PersistEncryptedCopy();
                }
            }
            else
            {
                CreateNewDatabase();
                PersistEncryptedCopy();
            }

            return LoadFromTempDatabase();
        }

        private bool IsDatabaseCorrupted(Exception ex)
        {
            return ex is SqliteException sqlEx && sqlEx.SqliteErrorCode == 26 ||
                   ex is InvalidDataException ||
                   ex.Message.Contains("not a database") ||
                   ex.Message.Contains("формат");
        }

        public void Save(Database db)
        {
            EnsureNotDisposed();
            if (db == null) throw new ArgumentNullException(nameof(db));

            using var connection = OpenConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Transaction = transaction;
                    cmd.CommandText = "DELETE FROM Users";
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = connection.CreateCommand())
                {
                    cmd.Transaction = transaction;
                    cmd.CommandText =
                        "INSERT INTO Users (UserName, PasswordHash, IsBlocked, PasswordPolicyOn, MinLength, ExpiryMonths, PasswordSetAt) " +
                        "VALUES ($name, $hash, $blocked, $policy, $minLength, $expiry, $setAt)";

                    foreach (var user in db.Users)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("$name", user.UserName);
                        cmd.Parameters.AddWithValue("$hash", user.PasswordHash ?? string.Empty);
                        cmd.Parameters.AddWithValue("$blocked", user.IsBlocked ? 1 : 0);
                        cmd.Parameters.AddWithValue("$policy", user.PasswordPolicyOn ? 1 : 0);
                        cmd.Parameters.AddWithValue("$minLength", user.MinLength);
                        cmd.Parameters.AddWithValue("$expiry", user.ExpiryMonths);
                        cmd.Parameters.AddWithValue("$setAt", user.PasswordSetAt.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture));
                        cmd.ExecuteNonQuery();
                    }
                }

                using (var cmd = connection.CreateCommand())
                {
                    cmd.Transaction = transaction;
                    cmd.CommandText =
                        "INSERT INTO Settings (Key, Value) VALUES ('HashAlgo', $algo) " +
                        "ON CONFLICT(Key) DO UPDATE SET Value = excluded.Value";
                    cmd.Parameters.AddWithValue("$algo", db.HashAlgo ?? "MD4");
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }

            PersistEncryptedCopy();
        }

        private Database LoadFromTempDatabase()
        {
            using var connection = OpenConnection();
            connection.Open();

            var db = new Database();

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT Value FROM Settings WHERE Key = 'HashAlgo' LIMIT 1";
                var result = cmd.ExecuteScalar();
                if (result is string algo && !string.IsNullOrWhiteSpace(algo))
                    db.HashAlgo = algo;
            }

            var users = new List<UserAccount>();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText =
                    "SELECT UserName, PasswordHash, IsBlocked, PasswordPolicyOn, MinLength, ExpiryMonths, PasswordSetAt FROM Users";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var dateValue = reader.IsDBNull(6) ? null : reader.GetString(6);
                    users.Add(new UserAccount
                    {
                        UserName = reader.GetString(0),
                        PasswordHash = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        IsBlocked = reader.GetInt32(2) != 0,
                        PasswordPolicyOn = reader.GetInt32(3) != 0,
                        MinLength = reader.GetInt32(4),
                        ExpiryMonths = reader.GetInt32(5),
                        PasswordSetAt = ParseDateTime(dateValue)
                    });
                }
            }

            db.Users = users.ToArray();

            // Явно закрываем соединение перед возвратом
            connection.Close();
            connection.Dispose();

            return db;
        }

        private void CreateNewDatabase()
        {
            using var connection = OpenConnection();
            connection.Open();

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText =
                    "CREATE TABLE IF NOT EXISTS Settings (Key TEXT PRIMARY KEY, Value TEXT NOT NULL);" +
                    "CREATE TABLE IF NOT EXISTS Users (" +
                    "UserName TEXT PRIMARY KEY," +
                    "PasswordHash TEXT NOT NULL," +
                    "IsBlocked INTEGER NOT NULL," +
                    "PasswordPolicyOn INTEGER NOT NULL," +
                    "MinLength INTEGER NOT NULL," +
                    "ExpiryMonths INTEGER NOT NULL," +
                    "PasswordSetAt TEXT NOT NULL" +
                    ");";
                cmd.ExecuteNonQuery();
            }

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "INSERT OR IGNORE INTO Settings(Key, Value) VALUES ('HashAlgo', 'MD4')";
                cmd.ExecuteNonQuery();
            }

            var emptyHash = PasswordHasher.Hash(string.Empty);
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText =
                    "INSERT OR IGNORE INTO Users (UserName, PasswordHash, IsBlocked, PasswordPolicyOn, MinLength, ExpiryMonths, PasswordSetAt) " +
                    "VALUES ('ADMIN', $hash, 0, 0, 0, 0, $setAt)";
                cmd.Parameters.AddWithValue("$hash", emptyHash);
                cmd.Parameters.AddWithValue("$setAt", DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        private void DecryptToTempFile()
        {
            try
            {
                using var fs = File.OpenRead(_encryptedPath);
                using var br = new BinaryReader(fs, Encoding.UTF8, leaveOpen: false);

                if (fs.Length < Magic.Length + 1 + 1 + 8 + 4)
                    throw new InvalidDataException("Файл слишком мал для быть валидной базой");

                var magic = Encoding.ASCII.GetString(br.ReadBytes(Magic.Length));
                if (!string.Equals(magic, Magic, StringComparison.Ordinal))
                    throw new InvalidDataException("Неверный формат файла");

                var modeByte = br.ReadByte();
                if (modeByte != 1)
                    throw new InvalidDataException("Ожидался режим CBC");

                var saltLength = br.ReadByte();
                if (saltLength != 0)
                {
                    br.ReadBytes(saltLength);
                    throw new InvalidDataException("Формат содержит соль, а должна быть без соли");
                }

                var iv = br.ReadBytes(8);
                var dataLength = br.ReadInt32();
                if (dataLength <= 0 || dataLength > 10 * 1024 * 1024)
                    throw new InvalidDataException("Некорректный размер данных");

                var cipher = br.ReadBytes(dataLength);

                var derived = DesPrimitives.DeriveNoSalt(EncryptionKey);
                var plain = DesPrimitives.Decrypt(cipher, derived.Key, iv);

                if (plain.Length >= 16)
                {
                    var sqliteHeader = Encoding.ASCII.GetString(plain, 0, 16);
                    if (!sqliteHeader.StartsWith("SQLite format 3"))
                        throw new InvalidDataException("Дешифрованные данные не являются валидной SQLite базой");
                }

                File.WriteAllBytes(_tempPath, plain);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка дешифровки: {ex.Message}", ex);
            }
        }


        private void PersistEncryptedCopy()
        {
            var plain = File.ReadAllBytes(_tempPath);
            var derived = DesPrimitives.DeriveNoSalt(EncryptionKey);
            var cipher = DesPrimitives.Encrypt(plain, derived.Key, derived.IV);

            using var ms = new MemoryStream();
            using (var bw = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
            {
                bw.Write(Encoding.ASCII.GetBytes(Magic));
                bw.Write((byte)1);
                bw.Write((byte)0);
                bw.Write(derived.IV);
                bw.Write(cipher.Length);
                bw.Write(cipher);
            }

            OverwriteFileWithZeros(_encryptedPath);
            File.WriteAllBytes(_encryptedPath, ms.ToArray());
        }

        private SqliteConnection OpenConnection()
        {
            var connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = _tempPath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Cache = SqliteCacheMode.Private,
                Pooling = false
            }.ToString();

            var connection = new SqliteConnection(connectionString);
            return connection;
        }

        private static DateTime ParseDateTime(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return DateTime.UtcNow;

            if (DateTime.TryParseExact(value, "O", CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal,
                    out var dt))
            {
                return dt;
            }
            return DateTime.UtcNow;
        }

        private static void OverwriteFileWithZeros(string path)
        {
            if (!File.Exists(path))
                return;

            var length = new FileInfo(path).Length;
            if (length <= 0)
            {
                File.Delete(path);
                return;
            }

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                var buffer = new byte[4096];
                long remaining = length;
                while (remaining > 0)
                {
                    int toWrite = (int)Math.Min(buffer.Length, remaining);
                    fs.Write(buffer, 0, toWrite);
                    remaining -= toWrite;
                }
                fs.Flush(true);
            }

            File.Delete(path);
        }

        private void EnsureNotDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(EncryptedSqliteStore));
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            // Даем время на завершение операций
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    if (File.Exists(_tempPath))
                    {
                        OverwriteFileWithZeros(_tempPath);
                        break;
                    }
                }
                catch (IOException) when (i < 4)
                {
                    System.Threading.Thread.Sleep(100);
                }
                catch
                {
                    break;
                }
            }

            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}