using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Student : BaseEntity
    {
        public int ID { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage ="Ad daxil edin")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad daxil edin")]
        public string Surname { get; set; }

        [Display(Name = "Ünvan")]
        [Required(ErrorMessage = "Ünvan daxil edin")]
        public string Address { get; set; }

        [Display(Name = "Doğum günü")]
        [Required(ErrorMessage = "Tarix daxil edin")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Sinif Nömrəsi")]
        [Required(ErrorMessage = "Sinif daxil edin")]
        public int? ClassID { get; set; }

        public byte[] Image { get; set; }

        [ForeignKey("ClassID")]
        public virtual TableClass TableClass { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
    }
}