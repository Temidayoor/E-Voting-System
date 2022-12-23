using E_Voting_System.Areas.Identity.Data;
using E_Voting_System.Data;
using Microsoft.AspNetCore.Identity;

namespace E_Voting_System.Models
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(E_Voting_SystemContext context, IServiceProvider 
            serviceProvider, UserManager<E_Voting_SystemUser> userManager)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Voter" };
            IdentityResult roleResult;
            foreach (var RoleName in roleNames)
            {
                var roleExists = await RoleManager.RoleExistsAsync(RoleName);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(RoleName));
                }
            }

            string Email = "temidayo.akinjeji@delonllc.com";
            string Password = "admin";
            if (userManager.FindByEmailAsync(Email).Result == null)
            {
                E_Voting_SystemUser user = new E_Voting_SystemUser();
                user.UserName = Email;
                user.Email = Email;
                IdentityResult result = userManager.CreateAsync(user, Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
