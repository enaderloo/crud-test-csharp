using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Data;

public abstract class BaseContextSeed
{
    protected readonly BaseDbContext _context;
    protected readonly ILogger _logger;
    public BaseContextSeed(BaseDbContext context, ILogger<BaseContextSeed> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger;
    }
    public async Task InitializeEnumType<T>() where T : Enumeration
    {
        if (await _context.Set<T>().CountAsync() != Enumeration.GetAll<T>().Count())
        {
            foreach (var type in Enumeration.GetAll<T>())
            {
                if (!await _context.Set<T>().AnyAsync(x => Equals(x, type)))
                    await _context.Set<T>().AddAsync(type);
            }
            await _context.SaveChangesAsync();
        }
    }
}
