using ManageStudents.API.Mappers;

namespace ManageStudents.API.Installers;

class MapperInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    services.AddAutoMapper(_ => { },
      typeof(TeacherProfile),
      typeof(StudentProfile),
      typeof(GradeProfile));
  }
}
