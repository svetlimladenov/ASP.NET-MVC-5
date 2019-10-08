using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MvcTemplate.Web.Controllers;
using MvcTemplate.Web.Models;

namespace MvcTemplate.Web.Services.Contacts
{
    public interface IPhonesServices
    {
        Phone CreatePhone(CreatePhoneInputModel inputModel, string id);

        PhoneDetailsViewModel GetPhoneDetails(string model);
    }
}
