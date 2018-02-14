using ITUniver.Calc.DB.Models;
using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.Calc.DB.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository() : base("User")
        {

        }
        public bool Check(string login, string password)
        {
            // todo - не оптимально!
            return GetAll().Any(u => u.Login == login && u.Password == password);
        }

        public bool Register(string Name, string Login, string Password, DateTime BirthDay, bool Sex)
        {
            // todo - не оптимально!
            return GetAll().Any(u => u.Name==Name && u.Login == Login && u.Password == Password && u.BirthDay==BirthDay && u.Sex == Sex);
        }


        public User GetByName(string login)
        {
            throw new NotImplementedException();
        }
    }
}