using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

using System.Data;

namespace Core.Data;

public class BaseDbContext : DbContext, IUnitOfWork
{
    protected virtual string DEFAULT_SCHEMA { get; set; }

    public virtual bool IsInMemoryContext { get; set; } = false;
    private readonly IMediator _mediator;
    private IDbContextTransaction _currentTransaction;

    public BaseDbContext(DbContextOptions options) : base(options) { }
    public BaseDbContext(DbContextOptions options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
    public bool HasActiveTransaction => _currentTransaction is not null;
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await _mediator.DispatchDomainEventsAsync(this);

        var result = await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IDbContextTransaction?> BeginTransactionAsync()
    {
        if (_currentTransaction is not null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction is null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            transaction.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction is not null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction is not null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
    protected void ConfigureEnumuration<T>(EntityTypeBuilder<T> obj) where T : Enumeration
    {
        obj.ToTable(typeof(T).Name, DEFAULT_SCHEMA);

        obj.HasKey(o => o.Id);

        obj.Property(o => o.Id)
            .ValueGeneratedNever()
            .IsRequired();

        obj.Property(o => o.Title)
            .HasMaxLength(128)
            .IsRequired();
        obj.Property(o => o.Description)
            .HasMaxLength(200)
            .IsRequired();
    }
}