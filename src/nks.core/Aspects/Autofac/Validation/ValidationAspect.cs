using Castle.DynamicProxy;
using FluentValidation;
using nks.core.Interceptors;
using nks.core.Validation;
namespace nks.core.Aspect;

public class ValidationAspect : MethodInterception
{
    private readonly Type _validatorType;

    public ValidationAspect(Type validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new Exception("Wrong validation type");
        }
        _validatorType = validatorType;
    }

    private IValidator? GenerateValidator()
    {
        return Activator.CreateInstance(_validatorType) as IValidator;
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var validator =  GenerateValidator();
        if (validator != null)
        {
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var entities = invocation.Arguments
                .Where( t=> entityType != null && t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
        throw new Exception("Validator instance cannot be initiated!");
    }

}
