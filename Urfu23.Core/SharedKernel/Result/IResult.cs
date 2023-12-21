namespace Urfu23.Core.SharedKernel.Result
{
    public interface IResult
    {
        bool IsSuccessfull { get; }
        void AddError(IError error);
        IError[] GetErrors();
    }
}