using Microsoft.EntityFrameworkCore;
using Urfu23.Core.Model;
using Urfu23.Core.SharedKernel.Repository;

namespace Urfu23.Infrastructure.Storage;

public class WebApplicationDbContext : DbContext , IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebApplicationDbContext).Assembly);
    }
}