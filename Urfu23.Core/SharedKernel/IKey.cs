namespace Urfu23.Core.SharedKernel
{
    public interface IKey<TEntity>
    {
        TEntity New();
    }
}