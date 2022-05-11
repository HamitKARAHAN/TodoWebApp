using Example.TodoWebApp.Global.BaseObjects.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
