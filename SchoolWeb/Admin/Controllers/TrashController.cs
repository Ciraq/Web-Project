using Admin.Constants;
using Admin.Models;
using Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TrashController : Controller
    {
        DataContext ctx = new DataContext();
        // GET: Trash
        public ActionResult Index()
        {
            var model = new StudentsTeachersMarksViewModel()
            {
                Students = ctx.Students.Where(s => s.Status == Enums.Status.Deleted).ToList(),
                Teachers = ctx.Teachers.Where(t => t.Status == Enums.Status.Deleted).ToList(),
                Marks = ctx.Marks.Where(m => m.Status == Enums.Status.Deleted).ToList()
            };
            return View(model);
        }

        public ActionResult RecoverStudents(int id)
        {
            var students = ctx.Students.FirstOrDefault(s => s.ID == id);
            students.Status = Enums.Status.Active;
            ctx.Entry(students).State = EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult RecoverTeachers(int id)
        {
            var teachers = ctx.Teachers.FirstOrDefault(t => t.ID == id);
            teachers.Status = Enums.Status.Active;
            ctx.Entry(teachers).State = EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult RecoverMarks(int id)
        {
            var marks = ctx.Marks.FirstOrDefault(m => m.ID == id);
            marks.Status = Enums.Status.Active;
            ctx.Entry(marks).State = EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("index");
        }

        [HandleError]
        public ActionResult RemoveStudents(int id)
        {
            var removedstudent = ctx.Students.FirstOrDefault(x => x.ID == id);
            ctx.Students.Remove(removedstudent);
            ctx.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult RemoveTeachers(int id)
        {
            var removedteacher = ctx.Teachers.FirstOrDefault(x => x.ID == id);
            ctx.Teachers.Remove(removedteacher);
            ctx.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult RemoveMarks(int id)
        {
            var removedmark = ctx.Marks.FirstOrDefault(x => x.ID == id);
            ctx.Marks.Remove(removedmark);
            ctx.SaveChanges();
            return RedirectToAction("index");
        }
    }
}