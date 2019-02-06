using Admin.Constants;
using Admin.Models;
using Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin,User,Teacher")]
    public class TeachersClassesController : Controller
    {
        DataContext ctx = new DataContext();
        // GET: StudentsClasses
        public ActionResult Index()
        {
            var teacherclasses = ctx.TeachersClasses.ToList();
            return View(teacherclasses);
        }
        public ActionResult ShowTeachers(int id)
        {
            var teachersclasses = ctx.TeachersClasses.Where(x => x.ClassID == id).ToList();
            return PartialView(teachersclasses);
        }

        public ActionResult ShowClasses(int id)
        {
            var teachersclasses = ctx.TeachersClasses.Where(x => x.TeacherID == id).ToList();
            return PartialView(teachersclasses);
        }

        public ActionResult Create()
        {
            var model = new TeachersClassesViewModel()
            {
                tableclasses = ctx.TableClasses.Where(x => x.Status == Enums.Status.Active).ToList(),
                teachers = ctx.Teachers.Where(x => x.Status == Enums.Status.Active).ToList(),
                teachersClasses=new TeachersClasses()
            };
            return View("TeachersForm",model);
        }

        public ActionResult Update(int id)
        {
            var model = new TeachersClassesViewModel()
            {
                teachers = ctx.Teachers.ToList(),
                tableclasses = ctx.TableClasses.ToList(),
                teachersClasses = ctx.TeachersClasses.FirstOrDefault(x => x.ID == id)
            };
            return View("TeachersForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TeachersClasses teachersclasses)
        {
            if (!ModelState.IsValid)
            {
                var model = new TeachersClassesViewModel()
                {
                    teachers=ctx.Teachers.ToList(),
                    tableclasses=ctx.TableClasses.ToList()
                };
                return View("TeachersForm");
            }
            if (teachersclasses.ID == 0)
            {
                ctx.TeachersClasses.Add(teachersclasses);
            }
            else
            {
                ctx.Entry(teachersclasses).State = EntityState.Modified;
            }
            ctx.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            var deletedteacherclasses = ctx.TeachersClasses.FirstOrDefault(x => x.ID == id);
            ctx.TeachersClasses.Remove(deletedteacherclasses);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}