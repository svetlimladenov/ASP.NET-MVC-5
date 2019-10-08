using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Panda_MVC5.Models;

namespace Panda_MVC5.DataModels
{
    public class Package
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        [ForeignKey("Recipient")]
        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }

    public enum Status
    {
        Pending = 1,
        Shipped = 2,
        Delivered = 3,
        Acquired = 4
    }
}