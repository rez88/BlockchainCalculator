using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.Calc.DB.Models
{
    public interface IUser: IEntity
    {
        string Name { get; set; }

        string Login { get; set; }

        string Password { get; set; }

        bool Sex { get; set; }

        DateTime? BirthDay { get; set; }
    }
}
