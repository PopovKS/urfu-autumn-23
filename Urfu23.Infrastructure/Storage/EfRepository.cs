using Microsoft.EntityFrameworkCore;
using Urfu23.Core.Model;
using Urfu23.Core.SharedKernel;
using Urfu23.Core.SharedKernel.Repository;
using Urfu23.Core.SharedKernel.Specifications;

namespace Urfu23.Infrastructure.Storage
{
    public class EFRepository<TEntity> : Repository<TEntity>
        where TEntity : BaseModel, IAggregateRoot
    {
        internal DbContext Context { get; }
        private DbSet<TEntity> _items => Context.Set<TEntity>();
        internal virtual IQueryable<TEntity> Items => ReadOnly ? _items.AsNoTracking() : _items;

        protected EFRepository(DbContext context) : base((IUnitOfWork) context)
        {
            Context = context;
        }

        public override async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct)
        {
            var entry = await _items.AddAsync(entity,ct);
            return entry.Entity;
        }

        public override Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct)
        {
            _items.AddRange(entities);
            return Task.CompletedTask;
        }

        public override Task RemoveAsync(TEntity entity)
        {
            _items.Remove(entity);
            return Task.CompletedTask;
        }

        public override Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _items.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public override Task<TEntity> FindAsync(long id, CancellationToken cancellationToken)
        {
            return FindAsync(id, cancellationToken, Context);
        }

        public Task<TEntity> FindAsync(long id, CancellationToken cancellationToken, DbContext context)
        {
            var keyProperty = context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties[0];
            return Items.FirstOrDefaultAsync(e => EF.Property<long>(e, keyProperty.Name) == id, cancellationToken);
        }

        public override Task<TEntity[]> ListAsync(CancellationToken cancellationToken)
        {
            return Items.ToArrayAsync(cancellationToken);
        }

        public override Task<TEntity[]> ListAsync(ISpecification<TEntity> specification,
            CancellationToken cancellationToken)
        {
            return Items.Where(specification.IsSatisfiedBy()).ToArrayAsync(cancellationToken);
        }

        public override Task<TEntity> SingleAsync(CancellationToken cancellationToken)
        {
            return Items.SingleAsync(cancellationToken);
        }

        public override Task<TEntity> SingleAsync(ISpecification<TEntity> specification,
            CancellationToken cancellationToken)
        {
            return Items.SingleAsync(specification.IsSatisfiedBy(), cancellationToken);
        }

        public override Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken)
        {
            return Items.SingleOrDefaultAsync(cancellationToken);
        }

        public override Task<TEntity> SingleOrDefaultAsync(ISpecification<TEntity> specification,
            CancellationToken cancellationToken)
        {
            return Items.SingleOrDefaultAsync(specification.IsSatisfiedBy(), cancellationToken);
        }

        public override Task<TEntity> FirstAsync(CancellationToken cancellationToken)
        {
            return Items.FirstAsync(cancellationToken);
        }

        public override Task<TEntity> FirstAsync(ISpecification<TEntity> specification,
            CancellationToken cancellationToken)
        {
            return Items.FirstAsync(specification.IsSatisfiedBy(), cancellationToken);
        }

        public override Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken)
        {
            return Items.FirstOrDefaultAsync(cancellationToken);
        }

        public override Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification,
            CancellationToken cancellationToken)
        {
            return Items.FirstOrDefaultAsync(specification.IsSatisfiedBy(), cancellationToken);
        }

        public override Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return Items.CountAsync(cancellationToken);
        }

        public override Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
        {
            return Items.CountAsync(specification.IsSatisfiedBy(), cancellationToken);
        }

        public override Task<long> LongCountAsync(CancellationToken cancellationToken)
        {
            return Items.LongCountAsync(cancellationToken);
        }

        public override Task<long> LongCountAsync(ISpecification<TEntity> specification,
            CancellationToken cancellationToken)
        {
            return Items.LongCountAsync(specification.IsSatisfiedBy(), cancellationToken);
        }

        public override Task<TResult[]> Query<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query,
            CancellationToken cancellationToken)
        {
            return query(Items).ToArrayAsync(cancellationToken);
        }
    }
}

