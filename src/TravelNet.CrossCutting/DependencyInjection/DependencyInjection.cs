using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelNet.Application.Services;
using TravelNet.Data.DataContext;
using TravelNet.Data.RepositoyGeneric;
using TravelNet.Domain.Interfaces.Repositories;
using TravelNet.Domain.Interfaces.Services;

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
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(BaseRpository<>));



            //Services
            services.AddScoped(typeof(IClienteService), typeof(ClienteService));


            return services;

        }
    }
}

