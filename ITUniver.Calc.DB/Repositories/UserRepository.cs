using ITUniver.Calc.DB.Models;
using System.Linq;

namespace ITUniver.Calc.DB.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public bool Check(string login, string password)
        {
            return GetAll($"[Login] = N'{login}' AND [Password] = N'{password}'").Count() == 1;
        }

        public User GetByName(string login)
        {
            return GetAll($"[Login] = N'{login}'").FirstOrDefault();
        }
    }
}
