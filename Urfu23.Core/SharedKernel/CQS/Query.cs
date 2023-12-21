using MediatR;
using Urfu23.Core.SharedKernel.Result;

namespace Urfu23.Core.SharedKernel.CQS
{
    public class Query<TResult>: IQuery<Result<TResult>>, IRequest<Result<TResult>>
    {
        
    }
}