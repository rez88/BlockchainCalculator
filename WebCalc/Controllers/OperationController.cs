using ITUniver.Calc.DB.Models;
using ITUniver.Calc.DB.NH.Repositories;
using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class OperationController : Controller
    {
        private IHistoryRepository HistoryRepository
           = new NHHistoryRepository();

        private IOperationRepository OperationRepository
            = new NHOperationRepository();
        // GET: Operation
        
        public ActionResult Index()
        {
            var statmodel = new Statistic();
            var model = new OperationModel();
            statmodel.Operation = OperationRepository.GetAll()
                .FirstOrDefault()
                .Name
                .ToString();
            statmodel.Count = HistoryRepository.GetAll()
                .Where(x=>x.Operation.Name==$"{statmodel.Operation}")
                .Count();
            statmodel.Avg = Convert.ToInt32(HistoryRepository.GetAll()
                .Where(x => x.Operation.Name == $"{statmodel.Operation}")
                .Select(x => x.ExecTime)
                .Average());       
                return View(statmodel);
            
        }
    }
}