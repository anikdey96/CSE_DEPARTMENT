using CSE_DEPARTMENT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSE_DEPARTMENT.Startup))]
namespace CSE_DEPARTMENT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }

        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

			var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
			var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            if (!rolemanager.RoleExists("SuperAdmin"))
            {
                //Create Default Role
                var role = new IdentityRole("SuperAdmin");
                rolemanager.Create(role);

                //Create Default Users
                var user = new ApplicationUser();
                user.UserName = "galib.cse@just.edu.bd";
                user.Email = "galib.cse@just.edu.bd";
                string pwd = "@galib123";
                var newuser = usermanager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    usermanager.AddToRole(user.Id, "SuperAdmin");
                }
            }

        }
    }
}
