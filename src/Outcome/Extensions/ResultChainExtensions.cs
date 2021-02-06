using System;
using System.Linq;
using Outcome.Interfaces;

namespace Outcome.Extensions
{
    public static class ResultChainExtensions
    {
        public static IResultChain<T> CheckIf<T>(this IResultChain<T> resultChain, bool isError, string propertyName, 
            string message)
        {
            var result = (Result<T>)resultChain;

            if (!isError)
            {
                return resultChain;
            }
            else
            {
                return result.AppendError(propertyName, message);
            }
        }

        public static IResultChain<T> CheckIf<T>(this IResultChain<T> resultChain, Func<bool> predicate, string propertyName,
            string message)
        {
            return CheckIf(resultChain, predicate(), propertyName, message);
        }
        
        public static Result<T> IfSucceeded<T>(this IResultChain<T> resultChain, T value)
        {
            var result = (Result<T>)resultChain;

            if (result.IsSuccess)
            {
                return new Result<T>(value, result.Errors.ToList());
            }
            else
            {
                return result;
            }
        }
    }
}