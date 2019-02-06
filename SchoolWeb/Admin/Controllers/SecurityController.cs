using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Admin.Controllers
{
    public class SecurityController : Controller
    {
        DataContext ctx = new DataContext();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            var userindb = ctx.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userindb != null)
            {
                FormsAuthentication.SetAuthCookie(userindb.UserName, false);
                return RedirectToAction("Index","Student");
            }
            else
            {
                ViewBag.message = "İstifadəçi adı və ya şifrə yanlış daxil edilib";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}