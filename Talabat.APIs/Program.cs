using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using Talabat.APIs.Extensions;
using Talabat.Applcation.ApplcationDependencies;
using Talabat.Domain.Entities.Accounts;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.InfrastructueDependinecies;

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
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(builder.Configuration["FrontUrl:Url"] ?? "http://localhost:4200");
                }
                );
            });
            // validation on Token 
            builder.Services.AddAuthentication(op => op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, op =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:secretkey"] ?? string.Empty));
                    op.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = key,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JWT:ValidAudience"],
                        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                        ValidateIssuer = true,
                        ClockSkew = TimeSpan.FromMinutes(3)
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
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
