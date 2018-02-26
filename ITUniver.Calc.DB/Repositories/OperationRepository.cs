using ITUniver.Calc.DB.Models;
using System.Linq;

namespace ITUniver.Calc.DB.Repositories
{
    public class OperationRepository: BaseRepository<Operation>, IOperationRepository
    {
        public Operation GetByName(string Name)
        {
            return GetAll($"[Name] = N'{Name}'").FirstOrDefault();
        }
    }
}
