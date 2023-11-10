using nks.core.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace nks.core.Caching;

public class CacheRemoveAspect : MethodInterception
{
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
