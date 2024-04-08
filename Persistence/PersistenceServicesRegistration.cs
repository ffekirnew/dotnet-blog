namespace BlogApp.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BlogApp.Persistence.Repositories;
using BlogApp.Application.Contracts.Persistence.Repositories;


public static class PersistenceServicesRegistration
{
  public static IServiceCollection ConfigurePersistenceServices(
      this IServiceCollection services,
      IConfiguration configuration
  )
  {
    services.AddDbContext<BlogAppDbContext>(options =>
        {
          options.UseNpgsql(configuration.GetConnectionString("DefaultConn"));
        });


    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    return services;
  }
}
