using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Torshia.Web.Controllers
{
    public class TasksController : Controller
    {
        // GET: Task
        public ActionResult Create()
        {
            return View();
        }
    }
}