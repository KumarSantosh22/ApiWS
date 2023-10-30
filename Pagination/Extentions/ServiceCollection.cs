using Pagination.Services.Contracts;
using Pagination.Services;
using Pagination.Models;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Pagination.Extentions
{
    public static class ServiceCollection
    {
        public static void AppServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
            services.AddScoped<ISieveProcessor, CustomSieveProcessor>();
            services.AddScoped<ITicketService, TicketService>();
        }
    }
}
