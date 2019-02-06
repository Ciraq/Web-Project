using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Admin.Constants.Enums;

namespace Admin.Models
{
    public class BaseEntity
    {
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}