using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Urfu23.Core.Model;

namespace Urfu23.Infrastructure.Storage.Mappings;

public class OrderEntityTypeMapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(x => x.Items);
    }
}