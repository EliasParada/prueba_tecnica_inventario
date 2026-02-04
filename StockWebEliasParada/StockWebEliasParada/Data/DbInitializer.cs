using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockWebEliasParada.Models.Entities;

namespace StockWebEliasParada.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(
            AppDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            context.Database.Migrate();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@local.com",
                    Nombres = "Admin",
                    Apellidos = "Sistema"
                };

                var result = await userManager.CreateAsync(user, "cdS2019*");

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(
                        ", ",
                        result.Errors.Select(e => e.Description)
                    ));
                }
            }
        }
    }
}
