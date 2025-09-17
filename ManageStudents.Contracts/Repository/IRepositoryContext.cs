using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace ManageStudents.Contracts.Repository;

public interface IRepositoryContext<in TContext> : IDisposable where TContext : DbContext
{
  DbSet<TEntity> Set<TEntity>() where TEntity : class;
  EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
  IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel = default);
  void CommitTransaction();
  void RollbackTransaction();
  int Save();
  Task<int> SaveAsync(CancellationToken cancellationToken = default);
}
