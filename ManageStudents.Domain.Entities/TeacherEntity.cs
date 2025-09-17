using ManageStudents.Domain.Entities.Base;

namespace ManageStudents.Domain.Entities;

public class TeacherEntity : AuditableEntity
{
  public Guid TeacherId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Mobile { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
  public ICollection<GradeEntity> Grades { get; set; } = [];
}
