using Drugstore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DrugstoreDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddScoped<IDrugstoreDbContext>(provider =>
                provider.GetService<DrugstoreDbContext>());

            return services;
        }
    }
}
