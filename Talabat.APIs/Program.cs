
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Talabat.APIs.Extensions;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Repository;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<ApplcationDbContext>(option =>
            { 
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            { 
                
                app.MapOpenApi();
                app.MapScalarApiReference();
                app.MapGet("/", () => Results.Redirect("/scalar/v1"));
                await app.ApplyMigration();
                
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
