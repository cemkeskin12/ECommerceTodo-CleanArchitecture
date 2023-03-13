using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECommerce.Client.Extensions.FluentValidation
{
    public static class FluentValidationExtensions
    {
        public static void AddToModelState(this ValidationResult result,ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
