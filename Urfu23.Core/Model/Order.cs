using Urfu23.Core.SharedKernel;

namespace Urfu23.Core.Model;

public class Order : BaseModel,  IAggregateRoot
{
    public List<OrderItem> Items { get; set; } = new();
    public long TotalPrice { get; set; }
}

public class OrderItem : ValueObject
{
    public long ProductId { get; set; }
    public int Qty { get; set; }
    public long Price { get; set; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return ProductId;
    }
}