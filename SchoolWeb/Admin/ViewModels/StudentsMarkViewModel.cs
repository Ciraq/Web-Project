using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.ViewModels
{
    public class StudentsMarkViewModel
    {
        public IEnumerable<Student> students { get; set; }
        public Mark mark { get; set; }
    }
}