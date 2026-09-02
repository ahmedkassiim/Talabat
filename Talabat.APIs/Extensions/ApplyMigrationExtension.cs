using Microsoft.EntityFrameworkCore;
using Talabat.Infrastructure.Persistence.Data;

namespace Talabat.APIs.Extensions
{
    public static class ApplyMigrationExtension
    {
       public static async Task ApplyMigration(this WebApplication app)
       {


            using var scope = app.Services.CreateScope();
            var dbContext =  scope.ServiceProvider.GetRequiredService<ApplcationDbContext>();
            await dbContext.Database.MigrateAsync();
            await ApplcationDbContextSeed.SeedAsync(dbContext);

        }

    }
}
