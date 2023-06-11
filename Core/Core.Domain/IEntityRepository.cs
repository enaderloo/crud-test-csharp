namespace Core.Domain;

public interface IEntityRepository<TEntity, PrimaryKeyType> where TEntity : BaseEntity<PrimaryKeyType>, IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
    Task<TEntity> CreateAsync(TEntity entity);
    IQueryable<TEntity> GetAll();
    Task<(IQueryable<TEntity>, int)> GetsAsync(IPagination pagination, string order = "", string filter = "");
    IQueryable<TEntity> Gets(int? pageSize, int? pageIndex, string? order, string filter);
    Task<TEntity?> FindAsync(PrimaryKeyType id);
    Task<TEntity?> GetWithIgnoreQueryFilterAsync(PrimaryKeyType id);
    Task<TEntity?> GetAsync(PrimaryKeyType id);
    Task DeleteAsync(PrimaryKeyType id);
    void Delete(TEntity entity);
    void Update(TEntity entity);
}
