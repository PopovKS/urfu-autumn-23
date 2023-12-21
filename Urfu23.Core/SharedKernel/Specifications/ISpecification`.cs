using System.Linq.Expressions;

namespace Urfu23.Core.SharedKernel.Specifications
{
    public interface ISpecification<TEntity>  where TEntity :  Entity, IAggregateRoot
    {
        Expression<Func<TEntity,bool>> IsSatisfiedBy();
    }
    
}