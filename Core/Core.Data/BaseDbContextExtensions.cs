
using Microsoft.EntityFrameworkCore;

namespace Core.Data;

public static class BaseDbContextExtensions
{
    public static DbSet<TEntityType> DbSet<TEntityType>(this BaseDbContext context)
        where TEntityType : class
    {
        return context.Set<TEntityType>();
    }
}
