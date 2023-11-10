using System.Transactions;
using Castle.DynamicProxy;
using nks.core.Interceptors;

namespace nks.core;

public class TransactionScopeAspect : MethodInterception
{
    public override void Intercept(IInvocation invocation)
    {
        using (TransactionScope transactionScope = new())
        {
            try
            {
                invocation.Proceed();
                transactionScope.Complete();   
            }
            catch (System.Exception)
            {
                transactionScope.Dispose();
                throw;
            }
        }
    }

}
