using System.Web.Mvc;

namespace WebCalc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
          
            return View();
        }

        public ActionResult Contact(long id, string name)
        {
            ViewData["Id"] = id;
            ViewBag.Namesfsdfsd = name;
            ViewBag.Message = $"Your contact page. {id} {name}";
            return View();
        }

        public ActionResult Empty(long id)
        {
            return Content($"id={id}");
        }

    }
}