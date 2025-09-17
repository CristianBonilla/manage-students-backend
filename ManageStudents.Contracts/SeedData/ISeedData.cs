using ManageStudents.Domain.Entities;

namespace ManageStudents.Contracts.SeedData;

public interface ISeedData
{
  SeedDataCollection<TeacherEntity> Teachers { get; }
  SeedDataCollection<StudentEntity> Students { get; }
  SeedDataCollection<GradeEntity> Grades { get; }
}
