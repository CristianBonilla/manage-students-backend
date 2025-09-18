using System.Reflection;
using ManageStudents.API.Installers;

namespace ManageStudents.API.Extensions;

static class InstallerExtensions
{
  public static void InstallServicesFromAssembly(
    this IServiceCollection services,
    IConfiguration configuration,
    IWebHostEnvironment env)
  {
    IInstaller[] installers = [.. Assembly.GetExecutingAssembly().GetTypes()
      .Where(type => typeof(IInstaller).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
      .Select(Activator.CreateInstance)
      .Cast<IInstaller>()];
    foreach (IInstaller installer in installers)
      installer.InstallServices(services, configuration, env);
  }
}
