using ManageStudents.Domain.Entities.Base;
using ManageStudents.Domain.Entities.Enums;

namespace ManageStudents.Domain.Entities;

public class GradeEntity : AuditableEntity
{
  public Guid GradeId { get; set; }
  public required Guid TeacherId { get; set; }
  public required Guid StudentId { get; set; }
  public required SubjectNames SubjectName { get; set; }
  public required float Value { get; set; }
  public TeacherEntity Teacher { get; set; } = null!;
  public StudentEntity Student { get; set; } = null!;
}
