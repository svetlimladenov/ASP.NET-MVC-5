using MvcTemplate.Web.Services.Contacts;

namespace MvcTemplate.Web.Services
{
    public class GreetingService : IGreetingService
    {
        public string SayHello()
        {
            return "Good Evening Adios!";
        }
    }
}