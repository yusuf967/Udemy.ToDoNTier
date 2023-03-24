using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Common.ResponseObjects;

namespace Udemy.ToDoNTier.Business.Extensions
{
    public static class ValidationResultExtensions
    {
        public static List<CustomValidationErrors> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationErrors> errors = new();
            foreach (var item in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage = item.ErrorMessage,
                    PropertyType = item.PropertyName
                });
            }
            return errors;
        }
    }
}
