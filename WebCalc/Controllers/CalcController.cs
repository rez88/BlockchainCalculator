using ConsoleCalc;
using ITUniver.Calc.DB.Models;
using ITUniver.Calc.DB.NH.Repositories;
using ITUniver.Calc.DB.Repositories;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    
    [Authorize]
    public class CalcController : Controller
    {
        private IOperationRepository Opers { get; set; }

        
        private IHistoryRepository HistoryRepository 
            = new NHHistoryRepository();

        private IOperationRepository OperationRepository 
            = new NHOperationRepository();

        private IUserRepository UserRepository
            = new NHUserRepository();

        private Calc Calc { get; set; }

        public CalcController()
        {
            var extPath = ConfigurationManager.AppSettings["ExtensionPath"];
            Calc = new Calc(extPath);
            Opers = new NHOperationRepository();
        }

        // GET: Calc
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = new OperationModel();
            model.Operations = OperationRepository.GetAll()
                .Select(x=>new SelectListItem { Text = $"{x.Name}", Value= $"{x.Name}" })
                .ToList();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Exec(OperationModel model)
        {
           
            // todo -> синхронизация операций

            var sw = new Stopwatch();
            sw.Start();
            model.Result = Calc.Exec(model.Oper.Name, model.Args.ToArray());
            sw.Stop();
            if (!ModelState.IsValid)
                return View();
            #region Save
            if (User.Identity.IsAuthenticated)
           
            {
                var item = new HistoryItem()
                {
                    Args = string.Join(" ", model.Args),
                    Operation = OperationRepository.GetByName(model.Oper.Name),
                    Result = model.Result,
                    Author = UserRepository.GetByName(User.Identity.Name),
                    ExecDate=DateTime.Now,
                    ExecTime = sw.ElapsedMilliseconds,
                };
                HistoryRepository.Save(item);
            #endregion
            }
            return Json(new { model.Result });
        }

        // GET: Calc
        public ActionResult History()
        {
            var history = User.IsInRole("admin") 
                ? HistoryRepository.GetAll()
                : UserRepository.GetByName(User.Identity.Name).History;
            
            return View(history);
        }
    }
}