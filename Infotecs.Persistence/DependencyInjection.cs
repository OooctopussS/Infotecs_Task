using Infotecs.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infotecs.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<InfotecsDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infotecs.WebApi"));
            });

            services.AddScoped<IInfotecsDbContext>(provider => provider.GetService<InfotecsDbContext>()!);

            return services;
        }
    }
}
