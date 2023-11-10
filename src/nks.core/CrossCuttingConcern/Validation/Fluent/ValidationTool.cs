using System.Reflection;
using FluentValidation;

namespace nks.core.Validation;

public static class ValidationTool
{
    public static void Validate<T>(IValidator validator, T entity) where T : class
    {
        if (entity == null )
        {
            throw new NullReferenceException("Validation entity cannot be null");
        }
        var validationContext = new ValidationContext<T>(entity, null, ValidatorOptions.Global.ValidatorSelectors.DefaultValidatorSelectorFactory());
        var validationResult = validator.Validate(validationContext);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }
}
