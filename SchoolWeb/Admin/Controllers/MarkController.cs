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
    [Authorize(Roles = "Admin,User,Teacher")]
    public class MarkController : Controller
    {
        DataContext ctx = new DataContext();
        // GET: Mark
        public ActionResult Index()
        {
                var marks = ctx.Marks.Where(m=>m.Status==Enums.Status.Active).ToList();
                return View(marks);  
        }

        public ActionResult Create()
        {
            var model = new StudentsMarkViewModel()
            {
                students = ctx.Students.Where(s => s.Status==Enums.Status.Active).ToList(),
                mark=new Mark()
            };
            return View("MarkForm",model);
        }

        public ActionResult Update(int id)
        {
            var model = new StudentsMarkViewModel()
            {
                students=ctx.Students.ToList(),
                mark=ctx.Marks.FirstOrDefault(x=>x.ID==id)
            };
            return View("MarkForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Mark mark)
        {
            if (!ModelState.IsValid)
            {
                var model = new StudentsMarkViewModel()
                {
                    students=ctx.Students.ToList(),
                    mark=mark
                };
                return View("MarkForm", model);
            }
            if (mark.ID==0)
            {
                mark.Status = Enums.Status.Active;
                mark.CreatedDate = DateTime.Now;
                ctx.Marks.Add(mark);
            }
            else
            {
                mark.CreatedDate = DateTime.Now;
                ctx.Entry(mark).State = EntityState.Modified;
            }
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deletedmark = ctx.Marks.FirstOrDefault(x => x.ID == id);
            deletedmark.Status = Enums.Status.Deleted;
            ctx.Entry(deletedmark).State = EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult ShowsMarks(int id)
        {
            using (var ctx=new DataContext())
            {
                var marks = ctx.Marks.Where(m => m.StudentID == id && m.Status == Enums.Status.Active).ToList();
                return PartialView(marks);
            }
            
        }
    }
}