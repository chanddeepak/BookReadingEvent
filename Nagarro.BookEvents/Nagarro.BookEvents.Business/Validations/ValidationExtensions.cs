using FluentValidation.Results;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Validations
{
    public static class ValidationExtensions
    {
        public static NagarroElectronicsValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<NagarroElectronicsValidationFailure> errors = new List<NagarroElectronicsValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new NagarroElectronicsValidationResult(errors);
        }

        public static NagarroElectronicsValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new NagarroElectronicsValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }

    }
}
