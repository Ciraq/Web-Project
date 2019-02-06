using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class TableClass : BaseEntity
    {
        public int ID { get; set; }

        [Display(Name = "Sinif nömrəsi")]
        [Required(ErrorMessage ="Sinif daxil edin")]
        public string ClassNo { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}