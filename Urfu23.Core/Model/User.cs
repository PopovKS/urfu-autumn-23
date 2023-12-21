using Urfu23.Core.SharedKernel;

namespace Urfu23.Core.Model;

public class User : BaseModel, IAggregateRoot
{
    public string Email { get; set; }
    public string FullName { get; set; }
}