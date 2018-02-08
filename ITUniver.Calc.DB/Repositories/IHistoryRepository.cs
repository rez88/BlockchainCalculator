using ITUniver.Calc.DB.Models;

namespace ITUniver.Calc.DB.Repositories
{
    public interface IHistoryRepository
    {
        IHistoryItem Find(long id);

        void Save(IHistoryItem item);

        void Delete(long id);
    }
}
