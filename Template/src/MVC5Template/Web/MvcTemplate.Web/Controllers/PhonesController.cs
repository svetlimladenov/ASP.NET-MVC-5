using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var list = new List<SelectListItem>();
            for (int i = 2000; i < DateTime.Now.Year; i++)
            {
                list.Add(new SelectListItem()
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }

            viewModel.AvaivableYears = list;
            return this.View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult ChildAction(int id)
        { 
            //some login - similar to ViewComponents in ASP.NET Core // Html.Action
            return this.PartialView("_ChildActionPartial",id);
        }


        [HttpPost]
        public ActionResult CreatePhone(CreatePhoneInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return null;
            }
            var phone = this.phonesServices.CreatePhone(inputModel, this.User.Identity.GetUserId());

            return this.RedirectToAction("Index");
        }
    }

    public class CreatePhoneInputModel
    {
        [Display(Name = "Phone Model")]
        public string Model { get; set; }

        public string Manufacter { get; set; }

        public string Year { get; set; }

        public ICollection<SelectListItem> AvaivableYears { get; set; }
    }
}