using lab1.Domain;

namespace lab1.Policies
{
    public class MinLengthRule : IPasswordRule
    {
        public bool Validate(string password, UserAccount user, out string error)
        {
            if (user.MinLength > 0 && password.Length < user.MinLength)
            { 
                error = $"Минимальная длина: {user.MinLength}"; 
                return false; 
            }
            error = string.Empty; 
            return true;
        }
    }

    public class NoEqualAdjacentRule : IPasswordRule
    {
        public bool Validate(string password, UserAccount user, out string error)
        {
            for (int i = 1; i < password.Length; i++)
                if (password[i] == password[i - 1])
                { error = "Подряд идущие одинаковые символы запрещены"; return false; }
            error = string.Empty; return true;
        }
    }
}
