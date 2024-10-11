using Core.Entities.Identity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Data;

namespace Web.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> SeedData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRoles(roleManager, context);
            await SeedAdmin(userManager, context);

            return app;
        }

        private static async Task SeedAdmin(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            var user = new ApplicationUser
            {
                UserName = "admin@hms.com",
                Email = "admin@hms.com",
                FirstName = "Admin",
                LastName = "Admin",
                DateOfBirth = DateTime.Now.AddYears(-30),
                IsOnline = false,
                NormalizedEmail = "admin@hms.com".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                LockoutEnabled = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
            };

            await userManager.CreateAsync(user);
            await userManager.AddPasswordAsync(user, "Pass1234!");
            await userManager.AddToRoleAsync(user, "Administrator");
            await context.SaveChangesAsync();
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            string[] roles = [
                "Administrator",
                "Manager",
                "Employee",
                "Provider",
                "Patient"
            ];

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var concurrencyStamp = Guid.NewGuid().ToString("D");
                    var identityRole = new IdentityRole
                    {
                        Name = role,
                        NormalizedName = role.ToUpper(),
                        ConcurrencyStamp = concurrencyStamp
                    };

                    await roleManager.CreateAsync(identityRole);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
