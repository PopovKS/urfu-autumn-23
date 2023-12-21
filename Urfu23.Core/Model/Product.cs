using Urfu23.Core.SharedKernel;

namespace Urfu23.Core.Model;

public class Product : BaseModel, IAggregateRoot
{
    public string Name { get; set; }
    public long Price { get; set; }
}