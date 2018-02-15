using ConsoleCalc;
using ITUniver.Calc.DB.Models;
using ITUniver.Calc.DB.NH.Repositories;
using ITUniver.Calc.DB.Repositories;
using System;
using System.Linq;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        private IHistoryRepository HistoryRepository 
            = new NHHistoryRepository();

        private IOperationRepository OperationRepository 
            = new OperationRepository();

        private IUserRepository UserRepository
            = new NHUserRepository();

        // GET: Calc
        public ActionResult Index()
        {
            var calc = new Calc();

            var model = new OperationModel();

            model.Operations = calc.GetOpers().Select(
                o => new SelectListItem() {
                    Text = $"{o.Name}",
                    Value = $"{o.Name}"
                });

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OperationModel model)
        {
            var calc = new Calc();

            model.Operations = calc.GetOpers().Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}" });

            model.Result = calc.Exec(model.Operation, model.Args.ToArray());

            #region Save

            var item = new HistoryItem();
            item.Args = string.Join(" ", model.Args);
            item.Operation = OperationRepository
                .GetAll($"[Name] = N'{model.Operation}'")
                .FirstOrDefault()
                .Id;
            item.Result = model.Result;
            item.ExecDate = DateTime.Now;
            item.Author = UserRepository.GetByName(User.Identity.Name);

            HistoryRepository.Save(item);

            #endregion

            return View(model);
        }

        // GET: Calc
        public ActionResult History()
        {
            var hist = UserRepository.GetByName(User.Identity.Name).History;
            
            return View(hist);
        }
    }
}