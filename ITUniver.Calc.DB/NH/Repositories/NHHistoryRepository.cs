using ITUniver.Calc.DB.Repositories;
using System;
using ITUniver.Calc.DB.Models;
using NHibernate.Criterion;
using System.Linq;
using System.Collections.Generic;

namespace ITUniver.Calc.DB.NH.Repositories
{
    public class NHHistoryRepository : NHBaseRepository<HistoryItem>, IHistoryRepository
    {
        public IEnumerable<HistoryItem> HistoryByUser(string login)
        {
            return GetAll();
        }
    }
}
