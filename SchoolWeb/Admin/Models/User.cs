using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage ="Boş buraxıla bilməz")]
        [EmailAddress]
        [Display(Name ="Poçt ünvanı")]
        public string Email { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="Adın uzunluğu {0} və {1} aralığında olmalıdır",MinimumLength =2)]
        [Display(Name = "İstifadəçi")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Boş buraxıla bilməz")]
        [StringLength(100)]
        [Display(Name = "Şifrə")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Boş buraxıla bilməz")]
        [Display(Name = "Rol")]
        public string UserRole { get; set; }

        public byte[] UserImage { get; set; }



    }
}