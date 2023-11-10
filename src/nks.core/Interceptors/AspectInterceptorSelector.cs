﻿using System.Reflection;
using Castle.DynamicProxy;

namespace nks.core.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true)
            .ToList();
        var methodAttributes = type
            .GetMethod(method.Name)
            ?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true)
            .ToList()
            ;
        if (methodAttributes != null)
        {
            classAttributes.AddRange(methodAttributes);
        }
        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}
