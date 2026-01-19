using Jobs.Core.Repositories;
using Jobs.Infrastructure.Persistence;
using Jobs.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Jobs.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddDbContext()
            .AddRepositories();
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddScoped<JobsDbContext>();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, JobRepository>();
        return services;
    }
}
