using Microsoft.EntityFrameworkCore;
using Urfu23.Core.Model;

namespace Urfu23.Infrastructure.Storage.Repositories;

public class ProductRepository : EFRepository<Product>
{
    protected ProductRepository(DbContext context) : base(context)
    {
    }
}