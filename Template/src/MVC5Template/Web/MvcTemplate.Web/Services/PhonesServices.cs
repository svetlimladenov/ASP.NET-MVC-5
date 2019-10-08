using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using MvcTemplate.Web.Controllers;
using MvcTemplate.Web.Models;
using MvcTemplate.Web.Services.Contacts;

namespace MvcTemplate.Web.Services
{
    public class PhonesServices : IPhonesServices
    {
        private readonly ApplicationDbContext dbContext;

        public PhonesServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Phone CreatePhone(CreatePhoneInputModel inputModel, string id)
        {
            var phone = new Phone()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = id,
                Manufacter = inputModel.Manufacter,
                Model = inputModel.Model,
            };

            this.dbContext.Phones.Add(phone);

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                this.dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


            return phone;
        }

        public PhoneDetailsViewModel GetPhoneDetails(string model)
        {
            var phone = this.dbContext.Phones.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());
            if (phone == null)
            {
                throw new ArgumentException("Invalid phone");
            }
            var viewModel = new PhoneDetailsViewModel()
            {
                Manufacter =  phone.Manufacter,
                Model = phone.Model,
                Year = DateTime.UtcNow.Year.ToString()
            };

            return viewModel;
        }
    }
}