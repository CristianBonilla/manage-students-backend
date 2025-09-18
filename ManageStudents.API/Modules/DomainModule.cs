using Autofac;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Services;
using ManageStudents.Infrastructure.Repositories;
using ManageStudents.Infrastructure.Repositories.Interfaces;

namespace ManageStudents.API.Modules;

class DomainModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<TeacherRepository>()
      .As<ITeacherRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentRepository>()
      .As<IStudentRepository>()
      .InstancePerLifetimeScope();
    builder.RegisterType<GradeRepository>()
      .As<IGradeRepository>()
      .InstancePerLifetimeScope();

    builder.RegisterType<TeacherService>()
      .As<ITeacherService>()
      .InstancePerLifetimeScope();
    builder.RegisterType<StudentService>()
      .As<IStudentService>()
      .InstancePerLifetimeScope();
    builder.RegisterType<GradeService>()
      .As<IGradeService>()
      .InstancePerLifetimeScope();
  }
}
