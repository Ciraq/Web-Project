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
    public class StudentController : Controller
    {
        DataContext ctx = new DataContext();
        public ActionResult Index()
        {
            var students = ctx.Students.Where(s => s.Status == Enums.Status.Active).ToList();
            return View(students);
        }

        public ActionResult ShowsStudents(int id)
        {
            var students = ctx.Students.Where(x => x.ClassID == id && x.Status == Enums.Status.Active).ToList();
            return PartialView(students);
        }

        public ActionResult Create()
        {
            var model = new StudentClassViewModel()
            {
                Classes = ctx.TableClasses.Where(x => x.Status == Enums.Status.Active).ToList(),
                Student = new Student()
            };
            return View(model);
        }

        public ActionResult Update(int id)
        {
            var student = ctx.Students.FirstOrDefault(x => x.ID == id);
            if (student == null)
                return HttpNotFound();

            var model = new StudentClassViewModel()
            {
                Classes = ctx.TableClasses.ToList(),
                Student = student
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                var model = new StudentClassViewModel()
                {
                    Classes = ctx.TableClasses.ToList(),
                    Student = student
                };
                return View("Create", model);
            }
            if (student.ID == 0)
            {
                if (file != null && file.ContentLength > 0)
                {
                    student.Image = new byte[file.ContentLength];
                    file.InputStream.Read(student.Image, 0, file.ContentLength);
                    student.Status = Enums.Status.Active;
                    student.CreatedDate = DateTime.Now;
                    ctx.Students.Add(student);
                }
                else
                {
                    ViewBag.message = "Şəkil daxil edilməlidir";
                    var model = student;
                    return View("Create", model);
                }

            }
            else if (!ModelState.IsValid)
            {
                var model = new StudentClassViewModel()
                {
                    Classes = ctx.TableClasses.ToList(),
                    Student = student
                };
                return View("Update", model);
            }
            else if (file != null && file.ContentLength > 0)
            {
                student.Image = new byte[file.ContentLength];
                file.InputStream.Read(student.Image, 0, file.ContentLength);
                student.CreatedDate = DateTime.Now;
                ctx.Entry(student).State = EntityState.Modified;
            }
            else
            {
                student.CreatedDate = DateTime.Now;
                ctx.Entry(student).State = EntityState.Modified;
            }
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var deletedstudent = ctx.Students.FirstOrDefault(x => x.ID == id);
            deletedstudent.Status = Enums.Status.Deleted;
            ctx.Entry(deletedstudent).State = EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("index");
        }
    }
}