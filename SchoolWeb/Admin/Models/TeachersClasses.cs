using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class TeachersClasses
    {
        public int ID { get; set; }

        [Display(Name = "Müəllim İD")]
        [Required(ErrorMessage = "İD seçilməlidir")]
        public int TeacherID { get; set; }

        [Display(Name = "Sinif Nömrəsi")]
        [Required(ErrorMessage ="Sinif seçilməlidir")]
        public int ClassID { get; set; }

        [ForeignKey("TeacherID")]
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("ClassID")]
        public virtual TableClass TableClass { get; set; }
    }
}