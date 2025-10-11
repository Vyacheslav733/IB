using lab1.Domain;
using System.Collections.Generic;

namespace lab1.Policies
{
    public static class PasswordPolicy
    {
        public static IEnumerable<IPasswordRule> ActiveRules(UserAccount u)
        {
            if (!u.PasswordPolicyOn) yield break;
            yield return new MinLengthRule();
            yield return new NoEqualAdjacentRule();
        }

        public static (bool ok, string? error) ValidateAll(string password, UserAccount u)
        {
            foreach (var r in ActiveRules(u))
                if (!r.Validate(password, u, out var err)) return (false, err);
            return (true, null);
        }
    }
}
