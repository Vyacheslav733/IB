namespace lab1.Policies
{
    public interface IPasswordRule
    {
        bool Validate(string password, Domain.UserAccount user, out string error);
    }
}
