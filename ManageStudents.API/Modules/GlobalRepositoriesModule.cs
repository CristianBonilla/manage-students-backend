using Autofac;
using ManageStudents.Contracts.Repository;
using ManageStudents.Infrastructure.Repositories;
using ManageStudents.Infrastructure.Repositories.Base;
using ManageStudents.Infrastructure.Repositories.Interfaces;

namespace ManageStudents.API.Modules;

class GlobalRepositoriesModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(RepositoryContext<>))
      .As(typeof(IRepositoryContext<>))
      .InstancePerLifetimeScope();
    builder.RegisterGeneric(typeof(Repository<,>))
      .As(typeof(IRepository<,>))
      .InstancePerLifetimeScope();
    builder.RegisterType<ManageStudentsRepositoryContext>()
      .As<IManageStudentsRepositoryContext>()
      .InstancePerLifetimeScope();
  }
}
