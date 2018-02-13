using ConsoleCalc;
using ITUniver.Calc.WinFormApp;
using System.Linq;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            
            var calc = new Calc();
            var oper = calc.GetOperNames();
            ViewBag.array = oper;
            return View();
        }

        public ActionResult History()
        {
            var array = MyHelper.GetAll();
            ViewBag.array = array;

            var calc = new Calc();
            var oper = calc.GetOpers();


            return View();
        }

        [HttpPost]
        public ActionResult Index(OperationModel model)
        {
            var calc = new Calc();

            model.Result = calc.Exec(model.Operation, model.Args.ToArray());

            return View(model);
        }
        

    }
}