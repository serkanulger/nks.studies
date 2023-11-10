using Microsoft.Extensions.DependencyInjection;
using nks.core.IoC;

namespace nks.core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, 
        ICoreModule[] modules)
    {
        foreach (var model  in modules)
        {
            model.Load(services);
        }
        return ServiceTool.Create(services);
    }
}
