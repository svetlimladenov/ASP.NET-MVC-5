using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MvcTemplate.Web.Services.Contacts;

namespace MvcTemplate.Web.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IPhonesServices phonesServices;

        public PhonesController(IPhonesServices phonesServices)
        {
            this.phonesServices = phonesServices;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        
        public ActionResult CreatePhone()
        {
            var viewModel = new CreatePhoneInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult CreatePhone(CreatePhoneInputModel inputModel)
        {
            var phone = this.phonesServices.CreatePhone(inputModel, this.User.Identity.GetUserId());

            return this.RedirectToAction("Index");
        }
    }

    public class CreatePhoneInputModel
    {
        public string Model { get; set; }

        public string Manufacter { get; set; }
    }
}