using System;
using System.Collections.Generic;
using System.Linq;

namespace Outcome.Exceptions
{
    public class ResultFailException : Exception
    {
        public IReadOnlyCollection<Error> Errors { get; }

        public ResultFailException(IReadOnlyCollection<Error> errors)
            : base(BuildErrorMessage(errors))
        {
            Errors = errors;
        }

        private static string BuildErrorMessage(IEnumerable<Error> errors)
        {
            var arr = errors.Select(x => $"{Environment.NewLine} -- {x.PropertyName}: {x.ErrorMessage}");
            return Messages.ValueIsInaccessibleForFailure + string.Join(string.Empty, arr);
        }
    }
}