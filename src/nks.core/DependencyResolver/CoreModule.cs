using Microsoft.Extensions.DependencyInjection;
using nks.core.Caching;
using nks.core.IoC;

namespace nks.core.DependencyResolver;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheManager, MemoryCacheManager>();
    }

}
