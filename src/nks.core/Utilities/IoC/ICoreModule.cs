using Microsoft.Extensions.DependencyInjection;

namespace nks.core.IoC;

public interface ICoreModule
{
    void Load(IServiceCollection services);
}
