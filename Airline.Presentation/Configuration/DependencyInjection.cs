using Airline.Application.Interfaces;
using Airline.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Airline.Presentation.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DbConnection")));
        services.AddScoped<IDataContext, DataContext>();
        
        DbInitializer.Initialize(services.BuildServiceProvider().GetService<DataContext>());

        return services;
    }
}