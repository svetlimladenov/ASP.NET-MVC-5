using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTemplate.Web.Models
{
    public class Phone
    {
        [Key]
        public string Id { get; set; }

        public string Model { get; set; }

        public string Manufacter { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}