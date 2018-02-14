using ITUniver.Calc.DB.Models;
using ITUniver.Calc.DB.Repositories;
using System.Web.Mvc;
using System.Web.Security;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserRepository UserRepository
            = new UserRepository();
        private IUserRepository Users { get; set; }

        public AccountController()
        {
            Users = new UserRepository();
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if (Users.Check(model.Login, model.Password))
            {
                // поставить отметку о аутентификации
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Index", "Calc");
            }

            ModelState.AddModelError("", "Не удалось выполнить вход");

            return View();
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
           // if (!ModelState.IsValid)
           //     return View();

            if (Users.Register(model.Name, model.Login, model.Password, model.BirthDay, model.Sex))
            {

                ModelState.AddModelError("", "Такой пользователь уже зарегистрирован");
                /* FormsAuthentication.SetAuthCookie(model.Login, true);
                 return RedirectToAction("Index", "Calc");*/
            }

            #region СОХРАНИТЬ

            var item = new User();
            item.Name = model.Name;
            item.Login = model.Login;
            item.Password = model.Password;
            item.BirthDay = model.BirthDay;
            item.Sex = model.Sex;

            UserRepository.Save(item);


            #endregion
            

            return View();
        }

    }
}