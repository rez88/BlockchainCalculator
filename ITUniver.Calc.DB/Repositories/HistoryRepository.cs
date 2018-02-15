using ITUniver.Calc.DB.Models;
using System.Collections.Generic;

namespace ITUniver.Calc.DB.Repositories
{
    public class HistoryRepository : BaseRepository<HistoryItem>, IHistoryRepository
    {
        public HistoryRepository() : base("History")
        {

        }

        public IEnumerable<HistoryItem> HistoryByUser(string login)
        {
            var userRep = new UserRepository();

            var user = userRep.GetByName(login);

            return GetAll($"[Author] = {user.Id}");
        }
    }
}
