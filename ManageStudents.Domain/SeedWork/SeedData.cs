using ManageStudents.Contracts.SeedData;
using ManageStudents.Domain.Entities;
using ManageStudents.Domain.SeedWork.Collections;

namespace ManageStudents.Domain.SeedWork;

public class SeedData : ISeedData
{
  public SeedDataCollection<TeacherEntity> Teachers => AllCollections.Teachers;
  public SeedDataCollection<StudentEntity> Students => AllCollections.Students;
  public SeedDataCollection<GradeEntity> Grades => AllCollections.Grades;
}
