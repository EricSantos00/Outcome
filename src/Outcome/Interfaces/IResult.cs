namespace Outcome.Interfaces
{
    public interface IResult<out T>
    {
        T Value { get; }
        bool IsSuccess { get; }
        bool IsFailure { get; }
    }
}