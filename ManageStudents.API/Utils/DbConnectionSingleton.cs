using System.Data.Common;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ManageStudents.Contracts.Enums;

namespace ManageStudents.API.Utils;

using ContextScope = (AsyncServiceScope scope, DbContext context, DatabaseFacade database);

class DbConnectionSingleton
{
  static Lazy<DbConnectionSingleton>? _instance;
  readonly IHost _host;

  private DbConnectionSingleton(IHost host) => _host = host;

  public static DbConnectionSingleton Start(IHost host)
  {
    _instance ??= new(() => new(host));

    return _instance.Value;
  }

  public async Task Connect<TContext>(DbConnectionType connectionType) where TContext : DbContext
  {
    int delay = 0;
    do
    {
      var (scope, _, database) = GetContextScope<TContext>();
      try
      {
        await using (scope.ConfigureAwait(false))
        {
          await (connectionType switch
          {
            DbConnectionType.OpenConnection => database.OpenConnectionAsync(),
            DbConnectionType.EnsureCreated => database.EnsureCreatedAsync(),
            DbConnectionType.EnsureDeleted => database.EnsureDeletedAsync(),
            DbConnectionType.Migration => database.MigrateAsync(),
            _ => throw new ArgumentOutOfRangeException(nameof(connectionType), $"Not expected DB connection type: {connectionType}")
          });
          delay = 0;
          Console.WriteLine($"{typeof(TContext).Name} DB connection started successfully.");
        }
      }
      catch (PlatformNotSupportedException)
      {
        Console.WriteLine("Unhandled exception due to incompatibility for DB connection.");

        throw;
      }
      catch (InvalidOperationException)
      {
        Console.WriteLine("Unhandled exception while DB connection.");

        throw;
      }
      catch (DbException exception) when (exception.InnerException is SocketException socketException && socketException.SocketErrorCode == SocketError.HostNotFound)
      {
        Console.WriteLine("Unidentified or nonexistent DB connection.");
        Console.WriteLine(exception.Message);

        throw socketException;
      }
      catch (DbException exception) when (exception.InnerException is null)
      {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.WriteLine(exception.Message);
        Console.WriteLine($"{++delay} seconds have passed, retrying DB connection...");
      }
    } while (delay > 0);
  }

  public async Task<bool> TestConnection<TContext>() where TContext : DbContext
  {
    var (_, _, database) = GetContextScope<TContext>();

    return await database.CanConnectAsync();
  }

  private ContextScope GetContextScope<TContext>() where TContext : DbContext
  {
    AsyncServiceScope scope = _host.Services.CreateAsyncScope();
    TContext context = scope.ServiceProvider.GetRequiredService<TContext>();
    DatabaseFacade database = context.Database;

    return (scope, context, database);
  }
}
