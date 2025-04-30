using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProductCatalogAPI.Infrastructure.DatabaseContext;
using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Infrastructure.Repositories;
using ProductCatalogAPI.Application.Contracts.Logging;
using ProductCatalogAPI.Services.Logging;

namespace ProductCatalogAPI.Infrastructure;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductCatalogContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}
