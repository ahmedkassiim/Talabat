using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talabat.Domain.Entities.Accounts;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.APIs.Extensions
{
    public static class ApplyMigrationExtension
    {
        public static async Task ApplyMigration(this WebApplication app)
        {


            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplcationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplcationUser>>();
            await dbContext.Database.MigrateAsync();
            await ApplcationIdentityDbContextSeed.SeedUserAsync(userManager);
            await ApplcationDbContextSeed.SeedAsync(dbContext);


        }

    }
}
