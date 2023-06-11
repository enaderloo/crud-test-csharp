using Extensions;

using Microsoft.EntityFrameworkCore;

using System.Linq.Dynamic.Core;

namespace Core.Data;
public abstract class BaseRepository<TEntity, PrimaryKeyType> : IEntityRepository<TEntity, PrimaryKeyType> where TEntity : BaseEntity<PrimaryKeyType>, IAggregateRoot
{
    protected readonly BaseDbContext _context;

    public IUnitOfWork UnitOfWork
    {
        get
        {
            return _context;
        }
    }

    public BaseRepository(BaseDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);

        return entity;
    }


    public virtual IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().AsNoTracking().AsQueryable();
    }

    public virtual IQueryable<TEntity> Gets(int? pageSize, int? pageIndex, string filter, string? order)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(filter.Trim().Trim('&'));

        if (!string.IsNullOrWhiteSpace(order))
            query = query.OrderBy(order);

        return query.ApplyPagination(pageSize, pageIndex);
    }
    public virtual async Task<(IQueryable<TEntity>, int)> GetsAsync(IPagination pagination, string order = "", string filter = "")
    {
        IQueryable<TEntity> query = _context.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable();
        return await ApplyFilteringAndPagination(query, pagination, order, filter);
    }
    protected async Task<(IQueryable<TEntity>, int)> ApplyFilteringAndPagination(IQueryable<TEntity> query, IPagination pagination, string order, string filter)
    {
        if (!string.IsNullOrWhiteSpace(filter))
            query = query.Where(filter.Trim().Trim('&'));

        var filteredCount = await query.CountAsync();

        if (!string.IsNullOrWhiteSpace(order))
            query = query.OrderBy(order);

        return (query.ApplyPagination(pagination.PageSize, pagination.PageIndex), filteredCount);
    }

    public virtual async Task<TEntity?> FindAsync(PrimaryKeyType id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
    public virtual async Task<TEntity?> GetWithIgnoreQueryFilterAsync(PrimaryKeyType id)
    {   
        return await _context.Set<TEntity>().IgnoreQueryFilters().FirstOrDefaultAsync(f => f.Id != null && f.Id.Equals(id));
    }

    public abstract Task<TEntity?> GetAsync(PrimaryKeyType id);


    public virtual async Task DeleteAsync(PrimaryKeyType id)
    {
        var entity = await FindAsync(id)?? throw new RecordNotFoundException("Record Not Found");
        Delete(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
}
