using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Panda_MVC5.Services
{
    public class CustomService : ICustomService
    {
        public string GetGreeting()
        {
            return "Hello";
        }
    }
}