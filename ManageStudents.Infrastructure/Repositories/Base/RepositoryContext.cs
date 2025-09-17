using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ManageStudents.Contracts.Repository;

namespace ManageStudents.Infrastructure.Repositories.Base;

public abstract class RepositoryContext<TContext>(TContext _context) : IRepositoryContext<TContext> where TContext : DbContext
{
  bool _disposed = false;

  public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class => _context.Entry(entity);

  public DbSet<TEntity> Set<TEntity>() where TEntity : class => _context.Set<TEntity>();

  public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = default) => _context.Database.BeginTransaction(isolationLevel);

  public void CommitTransaction() => _context.Database.CommitTransaction();

  public void RollbackTransaction() => _context.Database.RollbackTransaction();

  public int Save() => _context.SaveChanges();

  public Task<int> SaveAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (_disposed)
      return;
    if (disposing)
      _context.Dispose();
    _disposed = true;
  }
}
