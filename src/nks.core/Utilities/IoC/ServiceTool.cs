using Microsoft.Extensions.DependencyInjection;

namespace nks.core;

public static class ServiceTool
{
    // IoC Resolver 
    public static IServiceProvider ServiceProvider { get; internal set; }

    public static IServiceCollection Create(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
