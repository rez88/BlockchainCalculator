using ConsoleCalc;
using ITUniver.Calc.DB.Repositories;
using System.Linq;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CachingFilterAttribute : ActionFilterAttribute
    {
        private IHistoryRepository HistoryRepository
            = new HistoryRepository();
        public override void OnActionExecuted(ActionExecutedContext
    filterContext)
        {
            
            var model = new HistoryRepository();

            model.GetAll().Select(o => o.Operation == 1);
        }

    }
}