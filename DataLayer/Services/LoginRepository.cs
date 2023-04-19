using System.Linq;

namespace DataLayer
{
    public class LoginRepository : ILoginRepository
    {
        private CmsContext db;

        public LoginRepository(CmsContext context)
        {
            db = context;
        }

        public bool IsExistUser(string userName, string password)
        {
            return db.AdminLogins.Any(u => u.UserName == userName && u.Password == password);
        }
    }
}