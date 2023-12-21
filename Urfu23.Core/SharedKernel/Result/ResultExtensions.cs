namespace Urfu23.Core.SharedKernel.Result
{
    public static class ResultExtensions
    {
        public static T GetValue<T>(this IResult result)
        {
            if (!(result is IResult<T> genericResult))
            {
                throw new NotSupportedException("Result not contains additional value");
            }

            return genericResult.Value;
        }
    }
}