namespace Urfu23.Core.SharedKernel.Result
{
    public interface IError
    {
        string Type { get; }
        Dictionary<string, object> Data { get; }
    }
}