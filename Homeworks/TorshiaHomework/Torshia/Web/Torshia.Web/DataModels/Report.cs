using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Torshia.Web.Models;

namespace Torshia.Web.DataModels
{
    public class Report
    {
        public string Id { get; set; }

        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; }

        public string TaskId { get; set; }

        public virtual Task Task { get; set; }

        public string ReporterId { get; set; }

        public virtual ApplicationUser Reporter { get; set; }

    }
}