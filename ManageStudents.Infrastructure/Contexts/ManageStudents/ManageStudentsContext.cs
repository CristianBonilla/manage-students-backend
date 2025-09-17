using Microsoft.EntityFrameworkCore;
using ManageStudents.Contracts.SeedData;
using ManageStudents.Infrastructure.Contexts.ManageStudents.Config;
using ManageStudents.Infrastructure.Extensions;

namespace ManageStudents.Infrastructure.Contexts.ManageStudents;

public class ManageStudentsContext(DbContextOptions<ManageStudentsContext> _options, ISeedData? _seedData) : DbContext(_options)
{
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder
      .ApplyEntityTypeConfig<TeacherConfig>(_seedData)
      .ApplyEntityTypeConfig<StudentConfig>(_seedData)
      .ApplyEntityTypeConfig<GradeConfig>(_seedData);
  }
}
