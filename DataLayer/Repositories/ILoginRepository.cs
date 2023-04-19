namespace DataLayer
{
    public interface ILoginRepository
    {
        bool IsExistUser(string userName, string password);
    }
}