using ITUniver.Calc.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class OperationController : Controller
    {
        // GET: Operation
        public ActionResult Index()
        {
            var operations = new List<Operation>()
            {
                new Operation() { Id = 1, ArgsCount = 2, Name = "sum", Owner = "ituniver", CreationDate = DateTime.Now },
                new Operation() { Id = 1, ArgsCount = 2, Name = "sub", Owner = "ituniver", CreationDate = DateTime.Now },
                new Operation() { Id = 1, ArgsCount = 2, Name = "div", Owner = "ituniver", CreationDate = DateTime.Now },
                new Operation() { Id = 1, ArgsCount = 2, Name = "pow", Owner = "ituniver", CreationDate = DateTime.Now },
                new Operation() { Id = 1, ArgsCount = 2, Name = "credit", Owner = "ituniver", CreationDate = DateTime.Now },
            };

            return View(operations);
        }
    }
}