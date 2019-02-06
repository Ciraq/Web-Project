using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin,User,Teacher")]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotDeletedData()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}