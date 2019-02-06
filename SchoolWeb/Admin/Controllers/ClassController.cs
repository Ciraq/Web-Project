using Admin.Constants;
using Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin,User,Teacher")]
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            using (var ctx=new DataContext())
            {
                var classes = ctx.TableClasses.Where(m => m.Status == Enums.Status.Active).ToList();
                return View(classes);
            }
        }

        public ActionResult Create()
        {
            var model = new TableClass();
            return View("ClassForm", model);
        }

        public ActionResult Update(int id)
        {
            using (var ctx=new DataContext())
            {
                var classes = ctx.TableClasses.FirstOrDefault(x => x.ID == id);
                return View("ClassForm",classes);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TableClass _class)
        {
            using (var ctx = new DataContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("ClassForm");
                }
                if (_class.ID == 0)
                {
                    _class.Status = Enums.Status.Active;
                    _class.CreatedDate = DateTime.Now;
                    ctx.TableClasses.Add(_class);
                }
                else
                {
                    _class.CreatedDate = DateTime.Now;
                    ctx.Entry(_class).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new DataContext())
            {
                var deletedclass = ctx.TableClasses.FirstOrDefault(x => x.ID == id);
                deletedclass.Status = Enums.Status.Deleted;
                ctx.Entry(deletedclass).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}