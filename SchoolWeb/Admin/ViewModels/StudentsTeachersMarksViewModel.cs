using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.ViewModels
{
    public class StudentsTeachersMarksViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
    }
}