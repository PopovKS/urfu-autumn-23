using Urfu23.Core.SharedKernel.Result;

namespace Urfu23.Core.SharedKernel.CQS
{
    public abstract class QueryHandler<TQuery, TResult>: HandlerBase<TQuery, Result<TResult>>, IQueryHandler<TQuery, Result<TResult>>
        where TQuery : Query<TResult> 
    {
        protected QueryHandler()
        {
            InnerHandler = Handle;
        }
        
        public abstract Task<Result<TResult>> Handle(TQuery request, CancellationToken cancellationToken);
        
        protected Result<TResult> Successfull(TResult result)
        {
            return Result<TResult>.Successfull(result);
        }
        protected Result<TResult> Error(IError error)
        {
            return Result<TResult>.Error(error);
        }
    }
}