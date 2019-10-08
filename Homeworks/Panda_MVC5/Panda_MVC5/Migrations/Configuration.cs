using Microsoft.AspNet.Identity.EntityFramework;

namespace Panda_MVC5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Panda_MVC5.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Panda_MVC5.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var adminRole = new IdentityRole("Admin");
            var userRole = new IdentityRole("User");

            context.Roles.Add(adminRole);
            context.Roles.Add(userRole);
            context.SaveChanges();
        }
    }
}
