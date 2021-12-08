using Microsoft.AspNetCore.Identity;

namespace ParcelTrackingSystem.Data.SeedData
{
    public class SeedData
    {
        public async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] Roles = { "Admin" };
            IdentityResult roleResult;
            foreach (var role in Roles)
            {
                var roleExists = await RoleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
                }
            }
            string Email = "admin@pts.com";
            string Password = "Pa$$w0rd";
            if(userManager.FindByEmailAsync(Email).Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.Email = Email;
                user.UserName = Email;
                IdentityResult result = userManager.CreateAsync(user, Password).Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
