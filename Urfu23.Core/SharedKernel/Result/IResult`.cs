namespace Urfu23.Core.SharedKernel.Result
{
    public interface IResult<T> : IResult
    {
        T Value { get; }
    }
}