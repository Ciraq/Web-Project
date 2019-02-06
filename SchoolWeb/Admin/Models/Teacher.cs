using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Teacher : BaseEntity
    {
        public int ID { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage ="Ad daxil edilməlidir")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad daxil edilməlidir")]
        public string Surname { get; set; }

        [Display(Name = "Doğum günü")]
        [Required(ErrorMessage = "Doğum tarixi daxil edilməlidir")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Maaş")]
        [Range(300,5000,ErrorMessage ="Maaş 300 və 5000 aralığında olmalıdır")]
        [Required(ErrorMessage = "Maaş daxil edilməlidir")]
        public int? Salary { get; set; }

        [Display(Name = "Ünvan")]
        [Required(ErrorMessage = "Ünvan daxil edilməlidir")]
        public string Address { get; set; }

        [Display(Name = "Fənn")]
        [Required(ErrorMessage = "Fənn daxil edilməlidir")]
        public string Subject { get; set; }

        public byte[] Image { get; set; }
    }
}