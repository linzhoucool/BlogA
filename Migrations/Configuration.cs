namespace BlogApplication.Migrations
{
    using BlogApplication.Models;
 
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            // Classes to work with users and roles (provided by Microsoft packages)
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Check if the roles are already created.
            //If not, create them.
            if (!context.Roles.Any(r => r.Name == "LIN"))
            {
                roleManager.Create(new IdentityRole { Name = "Lin" });
            }

            if (!context.Roles.Any(r => r.Name == "Boss"))
            {
                roleManager.Create(new IdentityRole { Name = "Boss" });
            }

            //Check if the admin user is already created.
            //If not, create it.
            ApplicationUser PersonalUser = null;

            if (!context.Users.Any(p => p.UserName == "1159148810@.com"))
            {
                PersonalUser = new ApplicationUser();
                PersonalUser.UserName = "1159148810@qq.com";
                PersonalUser.Email = "1159148810@qq.com";
                PersonalUser.FirstName = "Lin";
                PersonalUser.LastName = "Zhou";
                PersonalUser.DisplayName = "Zhou Lin";

                userManager.Create(PersonalUser, "Password-1");
            }
            else
            {
                PersonalUser = context.Users.Where(p => p.UserName == "1159148810@qq.com.com")
                    .FirstOrDefault();
            }

            //Check if the PersonalUser is already on the Personal role
            //If not, add it.
            if (!userManager.IsInRole(PersonalUser.Id, "Lin"))
            {
                userManager.AddToRole(PersonalUser.Id, "Lin");
            }



            ApplicationUser adminUser = null;
            if (!context.Users.Any(p => p.UserName == "admin@myblogapp.com"))
            {
                adminUser = new ApplicationUser();
                adminUser.UserName = "admin@myblogapp.com";
                adminUser.Email = "admin@myblogapp.com";
                adminUser.FirstName = "Admin";
                adminUser.LastName = "User";
                adminUser.DisplayName = "Admin User";
                userManager.Create(adminUser, "Password-1");
            }
            else
            {
                adminUser = context.Users.Where(p => p.UserName == "admin@myblogapp.com")
                    .FirstOrDefault();
            }
            //Check if the adminUser is already on the Admin role
            //If not, add it.
            if (!userManager.IsInRole(adminUser.Id, "Admin"))
            {
                userManager.AddToRole(adminUser.Id, "Admin");
            }
        }
    }
}






