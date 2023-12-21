namespace Urfu23.Core.SharedKernel.Result
{
    public class Result : IResult
    {
        protected Result()
        {

        }

        public bool IsSuccessfull => _errors.Count < 1;

        private readonly List<IError> _errors = new List<IError>();

        public void AddError(IError error)
        {
            if(error == null) throw new ArgumentNullException($"{nameof(error)} must be not null");
            _errors.Add(error);
        }

        public IError[] GetErrors()
        {
            return _errors.ToArray();
        }
        
        public static Result Successfull()
        {
            return new Result();
        }
        public static Result Error(IError error)
        {
            var result = new Result();
            result.AddError(error);
            return result;
        }

    }
}