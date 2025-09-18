using Autofac.Extensions.DependencyInjection;
using ManageStudents.API.Utils;
using ManageStudents.Contracts.Enums;
using ManageStudents.Infrastructure.Contexts.ManageStudents;

namespace ManageStudents.API;

public class Program
{
  public static async Task Main(string[] args)
  {
    IHost host = CreateHostBuilder(args).Build();
    await DbConnectionSingleton.Start(host).Connect<ManageStudentsContext>(DbConnectionType.Migration);
    await host.RunAsync();
  }

  private static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .UseServiceProviderFactory(new AutofacServiceProviderFactory())
      .ConfigureWebHostDefaults(builder =>
      {
        builder.UseStartup<Startup>();
      });
}
