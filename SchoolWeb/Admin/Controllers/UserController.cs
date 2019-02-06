using Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        DataContext ctx = new DataContext();
        // GET: User
        public ActionResult Index()
        {
            var user = ctx.Users.ToList();
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
                var user = ctx.Users.FirstOrDefault(x => x.UserID == id);
                return View(user);
        }

        public ActionResult Save(User user, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                var model = user;
                return View("Create", model);
            }
            if (user.UserID == 0)
            {
                if (file != null && file.ContentLength > 0)
                {
                    user.UserImage = new byte[file.ContentLength];
                    file.InputStream.Read(user.UserImage, 0, file.ContentLength);
                    ctx.Users.Add(user);
                }
                else
                {
                    ViewBag.message = "Şəkil daxil edilməlidir";
                    var model = user;
                    return View("Create",model);
                }
            }
            else if (!ModelState.IsValid)
            {
                var model = user;
                return View("Update", model);
            }
            else if (file != null && file.ContentLength > 0)
            {
                user.UserImage = new byte[file.ContentLength];
                file.InputStream.Read(user.UserImage, 0, file.ContentLength);
                ctx.Entry(user).State = EntityState.Modified;
            }
            else
            {
                ctx.Entry(user).State = EntityState.Modified;
            }
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deleteduser = ctx.Users.FirstOrDefault(x => x.UserID == id);
            ctx.Users.Remove(deleteduser);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}