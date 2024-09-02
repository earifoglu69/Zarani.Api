using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zarani.Infrastructure.Context;
using Zarani.Infrastructure.Respositories;
using Zarani.Infrastructure.UnitOfWork;

namespace DogusOto.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void Configure(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ZaraniDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ZaraniConnection")));
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
