namespace Outcome.Exceptions
{
    internal static class Messages
    {
        public static readonly string ValueIsInaccessibleForFailure = "You attempted to access the Value property for a failed result. A failed result has no Value. The error was: ";
        public static readonly string PropertyNameIsNull = "The Property Name is null.";
        public static readonly string ErrorMessageIsNull = "The Error Message is null.";
    }
}