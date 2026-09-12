using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabat.Domain.Interfaces;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Repository;

namespace Talabat.Infrastructure.Persistence.InfrastructueDependinecies
{
    public static class InfrastructureDependancies
    {
        public static IServiceCollection ApplyInfrastructureDependancies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplcationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            return services;
        }
    }
}
