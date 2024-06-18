using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicaRevolution.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MedicaRevolutionDb");
        services.AddDbContext<MedicaRevolutionDbContext>(options =>
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());
        services.AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<MedicaRevolutionDbContext>();
    }
}
