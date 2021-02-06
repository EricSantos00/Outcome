using System.Collections.Generic;
using Outcome.Exceptions;
using Outcome.Interfaces;

namespace Outcome
{
    public class Result<T> : IResult<T>, IResultChain<T>
    {
        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new ResultFailException(_errors);

        private readonly List<Error> _errors;
        public IReadOnlyCollection<Error> Errors => _errors.AsReadOnly();

        public bool IsSuccess => _errors == null || _errors?.Count == 0;
        public bool IsFailure => !IsSuccess;

        internal Result(T value, List<Error> errors)
        {
            _errors = errors ?? new List<Error>();
            _value = value;
        }

        public static IResultChain<T> Ensure()
        {
            return new Result<T>(default, null);
        }

        public Result<T> AppendError(string propertyName, string message)
        {
            _errors.Add(new Error(propertyName, message));
            return new Result<T>(default, _errors);
        }
    }
}