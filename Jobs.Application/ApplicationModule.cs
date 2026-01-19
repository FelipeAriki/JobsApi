using Jobs.Application.Commands.CreateJob;
using Microsoft.Extensions.DependencyInjection;

namespace Jobs.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers();

        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateJobCommand>());
        return services;
    }
}
