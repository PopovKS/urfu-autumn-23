using Microsoft.EntityFrameworkCore;
using Urfu23.Core.Model;

namespace Urfu23.Infrastructure.Storage.Repositories;

public class UserRepository : EFRepository<User>
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}