using System;

namespace lab1.Domain
{
    public class UserAccount
    {
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsBlocked { get; set; }
        public bool PasswordPolicyOn { get; set; }
        public int MinLength { get; set; } = 0;
        public int ExpiryMonths { get; set; } = 0;
        public DateTime PasswordSetAt { get; set; } = DateTime.UtcNow;
    }

    public class Database
    {
        public int Version { get; set; } = 1;
        public string HashAlgo { get; set; } = "MD4";
        public UserAccount[] Users { get; set; } = Array.Empty<UserAccount>();
    }
}
