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
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            using (var ctx=new DataContext())
            {
                var teachers = ctx.Teachers.Where(t => t.Status == Enums.Status.Active).ToList();
                return View(teachers);
            }
        }

        public ActionResult Create()
        {
             return View();
        }

        public ActionResult Update(int id)
        {
            using (var ctx=new DataContext())
            {
                var teacher = ctx.Teachers.FirstOrDefault(x => x.ID == id);
                return View(teacher);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Teacher teacher,HttpPostedFileBase file)
        {
            using (var ctx=new DataContext())
            {
                if (!ModelState.IsValid)
                {
                    var model = teacher;
                    return View("Create", model);
                }
                if (teacher.ID==0)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        teacher.Image = new byte[file.ContentLength];
                        file.InputStream.Read(teacher.Image, 0, file.ContentLength);
                        teacher.Status = Enums.Status.Active;
                        teacher.CreatedDate = DateTime.Now;
                        ctx.Teachers.Add(teacher);
                    }
                    else
                    {
                        ViewBag.message = "Şəkil daxil edilməlidir";
                        var model = teacher;
                        return View("Create", model);
                    }
                }
                else if (!ModelState.IsValid)
                {
                    var model = teacher;
                    return View("Update", model);
                }
                else if(file!=null&&file.ContentLength > 0)
                {
                    teacher.Image = new byte[file.ContentLength];
                    file.InputStream.Read(teacher.Image, 0, file.ContentLength);
                    teacher.CreatedDate = DateTime.Now;
                    ctx.Entry(teacher).State = EntityState.Modified;
                }
                else
                {
                    teacher.CreatedDate = DateTime.Now;
                    ctx.Entry(teacher).State = EntityState.Modified;
                }
                ctx.SaveChanges();
                return RedirectToAction("index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var ctx=new DataContext())
            {
                var deletedteacher = ctx.Teachers.FirstOrDefault(x => x.ID == id);
                deletedteacher.Status = Enums.Status.Deleted;
                ctx.Entry(deletedteacher).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}