using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.ViewModels
{
    public class StudentClassViewModel
    {
        public IEnumerable<TableClass> Classes { get; set; }
        public Student Student { get; set; }
    }
}