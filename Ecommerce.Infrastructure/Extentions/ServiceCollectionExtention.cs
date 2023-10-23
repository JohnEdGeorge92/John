using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ecommerce.Infrastructure.DBContexts;

namespace Ecommerce.Infrastructure.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static void AddDbContextClient(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<ClientDashboardDBContext>(options =>
            {
                options.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly(typeof(ClientDashboardDBContext).Assembly.FullName)
                     .UseNetTopologySuite();
                });
            });
    }
}
