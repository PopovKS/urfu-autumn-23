using Microsoft.EntityFrameworkCore;
using Urfu23.Core.Model;

namespace Urfu23.Infrastructure.Storage.Repositories;

public class OrderRepository : EFRepository<Order>
{
    internal override IQueryable<Order> Items => base.Items.Include(x => x.Items);

    public OrderRepository(DbContext context) : base(context)
    {
    }
}