using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.ViewModels
{
    public class TeachersClassesViewModel
    {
        public IEnumerable<TableClass> tableclasses { get; set; }
        public IEnumerable<Teacher> teachers { get; set; }
        public TeachersClasses teachersClasses { get; set; }
    }
}