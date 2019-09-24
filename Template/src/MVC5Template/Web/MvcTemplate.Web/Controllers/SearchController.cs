using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTemplate.Web.Models;

namespace MvcTemplate.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SearchController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize]
        public ActionResult CacheMe()
        {
            var count = this.dbContext.Users.Count();
            return this.View(count);
        }
    }
}