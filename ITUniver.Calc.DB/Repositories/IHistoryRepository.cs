using ITUniver.Calc.DB.Models;
using System.Collections.Generic;

namespace ITUniver.Calc.DB.Repositories
{
    public interface IHistoryRepository : IBaseRepository<HistoryItem>
    {
        IEnumerable<HistoryItem> HistoryByUser(string login);
    }

    public interface IOperationRepository : IBaseRepository<Operation>
    {
    }
}
