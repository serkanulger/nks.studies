using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using nks.core.Interceptors;

namespace nks.core.DependencyInjection;

public static class AutofacExtension
{

    public static void RegisterProxy(this Module model, ContainerBuilder builder)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableClassInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }
            )
            .SingleInstance();

    }

}
