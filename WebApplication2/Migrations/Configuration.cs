namespace WebApplication2.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("User"));

            //Créer un utilisateur Admin
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
           

            var adminUser = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
            userManager.Create(adminUser, "Password123!");
            userManager.AddToRole(adminUser.Id, "Admin");

  

            base.Seed(context);
        }
    }
}
