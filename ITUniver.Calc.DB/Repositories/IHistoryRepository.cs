using ITUniver.Calc.DB.Models;

namespace ITUniver.Calc.DB.Repositories
{
    public interface IHistoryRepository : IBaseRepository<HistoryItem>
    {
    }

    public interface IOperationRepository : IBaseRepository<Operation>
    {
    }
}