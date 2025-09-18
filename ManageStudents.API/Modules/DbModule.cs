using Autofac;
using ManageStudents.Contracts.SeedData;
using ManageStudents.Domain.SeedWork;

namespace ManageStudents.API.Modules;

class DbModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<SeedData>()
      .As<ISeedData>()
      .InstancePerLifetimeScope();
  }
}
