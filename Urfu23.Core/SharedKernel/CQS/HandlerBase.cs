using MediatR;
using Urfu23.Core.SharedKernel.Result;

namespace Urfu23.Core.SharedKernel.CQS
{
    public abstract class HandlerBase<T, TResult> : IRequestHandler<T, TResult> where T : IRequest<TResult>
        where TResult : IResult
    {
        protected Func<T, CancellationToken, Task<TResult>> InnerHandler;
        
        async Task<TResult> IRequestHandler<T, TResult>.Handle(T request, CancellationToken cancellationToken)
        {
            return await CoreHandle(request, cancellationToken);
        }

        protected virtual async Task<TResult> CoreHandle(T request, CancellationToken cancellationToken)
        {
            if (InnerHandler == null)
            {
                throw new NullReferenceException();
            }
            
            return await InnerHandler?.Invoke(request, cancellationToken);
        }
    }
}