using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Web.Services;
using MvcTemplate.Web.Services.Contacts;

namespace MvcTemplate.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IGreetingService greetingService;

        public HomeController(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            this.ViewData["Greeting"] = greetingService.SayHello();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string NewsList(int page = 1)
        {
            return page.ToString();
        }

        public FileResult GetFile(string filename)
        {
            return this.File(filename, "application/octet-stream", "myfile.txt");
        }

    }
}