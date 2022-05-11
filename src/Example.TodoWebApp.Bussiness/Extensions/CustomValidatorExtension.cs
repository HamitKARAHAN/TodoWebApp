using Example.TodoWebApp.Global.BaseObjects.Concrete;
using FluentValidation.Results;

namespace Example.TodoWebApp.Bussiness.Extensions
{
    public static class CustomValidatorExtension
    {
        public static List<CustomValidationErrorModel> ConvertToCustomValidator(this ValidationResult validationResult)
        {
            var errors = new List<CustomValidationErrorModel>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }
            return errors;
        }
    }
}
