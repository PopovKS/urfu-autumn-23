using Urfu23.Core.SharedKernel.Result;

namespace Urfu23.Core.SharedKernel.CQS
{
    public abstract class CommandHandler<TCommand>: HandlerBase<TCommand, Result.Result>, ICommandHandler<TCommand>
         where TCommand : Command
    {
        protected CommandHandler()
        {
            InnerHandler = Handle;
        }
        
        public abstract Task<Result.Result> Handle(TCommand request, CancellationToken cancellationToken);
        
        protected Result.Result Successfull()
        {
            return Result.Result.Successfull();
        }
        protected Result.Result Error(IError error)
        {
            return Result.Result.Error(error);
        }
        
        protected Result<TResult> Successfull<TResult>(TResult result)
        {
            return Result<TResult>.Successfull(result);
        }
    }
}