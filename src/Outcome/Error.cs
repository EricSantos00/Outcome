using System;
using Outcome.Exceptions;

namespace Outcome
{
    public class Error
    {
        public string PropertyName { get; }
        public string ErrorMessage { get; }

        public Error(string propertyName, string errorMessage)
        {
            PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName), Messages.PropertyNameIsNull);
            ErrorMessage = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage), Messages.ErrorMessageIsNull);
        }
        
        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}