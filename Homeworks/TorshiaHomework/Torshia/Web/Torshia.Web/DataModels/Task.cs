using System;
using System.Collections.Generic;
using Torshia.Web.Models;

namespace Torshia.Web.DataModels
{
    public class Task
    {
        public Task()
        {
            this.Participants = new HashSet<ApplicationUser>();
        }
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; }

        public virtual AffectedSectors AffectedSectors { get; set; }
    }
}