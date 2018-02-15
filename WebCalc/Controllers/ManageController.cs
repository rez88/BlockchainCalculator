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
    public class ManageController : Controller
    {
        private IUserRepository Users { get; set; }

        public ManageController()
        {
            Users = new NHUserRepository();
        }

        // GET: Manage
        public ActionResult Index()
        {
            var users = Users.GetAll();
            return View(users);
        }

        public ActionResult Delete(long id)
        {
            var user = Users.Find(id);
            if (user != null)
            {
                user.Status = UserStatus.Deleted;
                Users.Save(user);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Ban(long id)
        {
            var user = Users.Find(id);
            if (user != null)
            {
                user.Status = UserStatus.Ban;
                Users.Save(user);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Active(long id)
        {
            var user = Users.Find(id);
            if (user != null)
            {
                user.Status = UserStatus.Active;
                Users.Save(user);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(long id)
        {
            var users = Users.GetAll()
    .Where(u => u.Id == id);
            return View(users);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(RegisterModel model)
        {
           
            if (!ModelState.IsValid)
                return View();

            if (Users.GetByName(model.Login) == null)
            {
                var user = new User()
                {
                    Login = model.Login,
                    Name = model.Name,
                    Sex = model.Sex,
                    BirthDay = model.BirthDay
                };
                Users.Save(user);

                // поставить отметку о аутентификации
                RedirectToAction("Index", "Manage");
            }
            else
            {
                ModelState.AddModelError("Login", "Придумайте другое имя. Это уже занято");
            }

            return View();
        }

        public ActionResult Status(UserStatus s)
        {
            
            var users = Users.GetAll().Where(u => u.Status == s);
            
            return View(users);
        }

    }
}