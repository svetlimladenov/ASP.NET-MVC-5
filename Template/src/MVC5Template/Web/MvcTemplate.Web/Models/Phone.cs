using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTemplate.Web.Models
{
    public class Phone
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string Manufacter { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}