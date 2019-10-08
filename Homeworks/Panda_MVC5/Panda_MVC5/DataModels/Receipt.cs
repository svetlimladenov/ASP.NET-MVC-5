using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Panda_MVC5.Models;

namespace Panda_MVC5.DataModels
{
    public class Receipt
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient  { get; set; }

        public string PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}