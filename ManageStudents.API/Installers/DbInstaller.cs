using ManageStudents.API.Utils;
using ManageStudents.Contracts.Enums;
using Microsoft.EntityFrameworkCore;
using ManageStudents.API.Options;
using ManageStudents.API.Utils;
using ManageStudents.Contracts.Enums;
using ManageStudents.Helpers;
using ManageStudents.Infrastructure.Contexts.ManageStudents;

namespace ManageStudents.API.Installers;

class DbInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    string connectionString = GetConnectionString(configuration);
    services.AddDbContextPool<ManageStudentsContext>((provider, options) =>
    {
      options.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine);
    });
  }

  private static string GetConnectionString(IConfiguration configuration)
  {
    string connectionStringKey = ApiConfigKeys.GetConnectionKeyFromProcessType();
    string connectionString = configuration.GetConnectionString(connectionStringKey)
      ?? throw new InvalidOperationException($"Connection string \"{connectionStringKey}\" not established");
    if (ApiConfigKeys.ProcessType == ProcessType.Local)
      DirectoryConfigHelper.SetConnectionStringFullPathFromDataDirectory(ref connectionString);

    return connectionString;
  }
}
