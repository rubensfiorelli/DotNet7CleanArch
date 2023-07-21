using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelNet.Data.DataContext;

namespace TravelNet.CrossCutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(opts => opts
                    .UseMySql(configuration.GetConnectionString("DbConnection"),
                     ServerVersion.AutoDetect(configuration.GetConnectionString("DbConnection")),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            //Repositories
            //services.AddScoped(typeof(IEventoRepository), typeof(EventoRepository));



            //Services
            //services.AddScoped(typeof(ILeadsService), typeof(LeadsService));


            return services;

        }
    }
}

