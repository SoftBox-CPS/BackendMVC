using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftBox.DataBase.InterfacesRepository;
using SoftBox.DataBase.Repository;

namespace SoftBox.DataBase;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection ConnectEFCoreDB(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<SoftBoxDbContext>(options =>
           {
               options.UseSqlServer(configuration.GetConnectionString("SoftBoxMS"));
           }, ServiceLifetime.Transient);

        services.AddScoped <Dictionary<Type, SoftBoxDbContext>>();
        services.AddSingleton<DbContextFactory>();
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}
