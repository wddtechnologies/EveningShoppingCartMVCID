using Microsoft.AspNetCore.Identity;
using BookStornMVCID.Constants;

namespace BookStornMVCID.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultDatat(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();
            //adding some roles to db
            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //create admin user 
            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true

            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
                if (userInDb is not null) 
            {
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }

        }
    }
}
