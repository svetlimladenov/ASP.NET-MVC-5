using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Torshia.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var isAdmin = this.User.IsInRole("Admin");
            var isUser = this.User.IsInRole("User");

            if (this.User.Identity.IsAuthenticated)
            {
                return this.View();
            }


            return View("IndexLoggedOut");
        }
    }
}