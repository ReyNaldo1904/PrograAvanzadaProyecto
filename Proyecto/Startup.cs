using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using Proyecto.Models;

[assembly: OwinStartupAttribute(typeof(Proyecto.Startup))]
namespace Proyecto
{
    public partial class Startup

    {

        public void Configuration(IAppBuilder app)

        {

            ConfigureAuth(app);

            InitializeRolesAndAdminUser();

        }

        private void InitializeRolesAndAdminUser()

        {

            using (var context = new ApplicationDbContext())

            {

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (!roleManager.RoleExists("Admin"))

                {

                    var role = new IdentityRole("Admin");

                    roleManager.Create(role);

                }

                if (!roleManager.RoleExists("User"))

                {

                    var role = new IdentityRole("User");

                    roleManager.Create(role);

                }

                if (userManager.FindByName("admin@domain.com") == null)

                {

                    var AdminUser = new ApplicationUser

                    {

                        UserName = "admin@domain.com",

                        Email = "admin@domain.com"

                    };

                    var adminPassword = "Admin123";

                    var userCreationResult = userManager.Create(AdminUser, adminPassword);

                    if (userCreationResult.Succeeded)
                    {

                        userManager.AddToRole(AdminUser.Id, "Admin");

                    }

                }

            }

        }

    }

}


