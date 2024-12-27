using AwarenessWebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace AwarenessWebsite.Persistence;

public class AdminDataSeed
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Admin","User" };
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var adminUser = await userManager.FindByEmailAsync("admin@gmail.com");
        if (adminUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
            };

            await userManager.CreateAsync(user, "Admin123!");


            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
