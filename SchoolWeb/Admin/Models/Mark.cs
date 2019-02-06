using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Mark : BaseEntity
    {
        public int ID { get; set; }

        [Display(Name ="Azərbaycan dili")]
        [Range(2,5,ErrorMessage ="Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage ="Boş buraxıla bilməz")]
        public int? Azerbaijani { get; set; }

        [Display(Name = "Riyaziyyat")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? Math { get; set; }

        [Display(Name = "Ədəbiyyat")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? Literature { get; set; }

        [Display(Name = "Fizika")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? Physics { get; set; }

        [Display(Name = "Kimya")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? Chemistry { get; set; }

        [Display(Name = "Coğrafiya")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? Geography { get; set; }

        [Display(Name = "Bialogiya")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? Biology { get; set; }

        [Display(Name = "İngilis dili")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? English { get; set; }

        [Display(Name = "Tarix")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? History { get; set; }

        [Display(Name = "İnformatika")]
        [Range(2, 5, ErrorMessage = "Qiymət 2 və 5 arasında olmalıdır")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? Informatics { get; set; }

        [Display(Name = "Rüb")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public string Semester { get; set; }

        [Display(Name = "Yekun")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public string Result { get; set; }

        [Display(Name = "Şagird İD")]
        [Required(ErrorMessage = "Boş buraxıla bilməz")]
        public int? StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}