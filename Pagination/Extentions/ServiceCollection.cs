using Pagination.Services.Contracts;
using Pagination.Services;
using Pagination.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using Pagination.Data;
using Pagination.Data.Contracts;

namespace Pagination.Extentions
{
    public static class ServiceCollection
    {
        public static void AppServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            // DBs
            services.AddDbContext<AppDbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<DapperDbContext>();

            // Sieve
            services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
            services.AddScoped<ISieveProcessor, CustomSieveProcessor>();

            // Respositories
            services.AddScoped(typeof(IRepositoryDapper<>), typeof(RepositoryDapper<>));

            // Services
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketDapperService, TicketDapperService>();
        }
    }
}
