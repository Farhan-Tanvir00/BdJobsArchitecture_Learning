using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Shared.Exceptions
{
    public class DtoValidationException : Exception
    {
        public IDictionary<string, string[]> ValidationErrors { get; }

        public DtoValidationException(IDictionary<string, string[]> validationErrors) :
            base("One or More Validation Exception Occured")
        {
            ValidationErrors = validationErrors;
        }
    }
}
