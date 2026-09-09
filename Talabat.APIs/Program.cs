
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using Talabat.APIs.Extensions;
using Talabat.Applcation.ApplcationDependencies;
using Talabat.Applcation.Services;
using Talabat.Domain.Entities.Accounts;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.InfrastructueDependinecies;
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
            builder.Services.AddIdentity<ApplcationUser, IdentityRole>()    
            .AddEntityFrameworkStores<ApplcationDbContext>()
            .AddDefaultTokenProviders();
            builder.Services.AddOpenApi();
            builder.Services.ApplyInfrastructureDependancies(builder.Configuration)
                            .ApplyApplcationDependencies();

            // validation on Token 
            builder.Services.AddAuthentication(op => op.DefaultAuthenticateScheme = "MySchema")
                .AddJwtBearer("MySchema", op => 
                {
                    var scuritKey = "Ahmed Kassim Will Generate a new Secrit Key To Added On JWT Token";

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(scuritKey));

                    op.TokenValidationParameters = new TokenValidationParameters()
                    {

                        IssuerSigningKey = key,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };


                });


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
            app.UseStaticFiles();   
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
