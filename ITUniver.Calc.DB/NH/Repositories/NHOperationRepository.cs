using ITUniver.Calc.DB.Repositories;
using ITUniver.Calc.DB.Models;

namespace ITUniver.Calc.DB.NH.Repositories
{
    public class NHOperationRepository : NHBaseRepository<Operation>, IOperationRepository
    {
        public Operation GetByName(string Name)
        {
            var session = Helper.GetCurrentSession();

            return session
                .QueryOver<Operation>()
                .And(u => u.Name == Name)
                .SingleOrDefault();

        }
    }
}
