using ManageStudents.Contracts.DTO.Base;
using ManageStudents.Domain.Entities.Enums;

namespace ManageStudents.Contracts.DTO.Teacher;

public class TeacherResponse : Auditable
{
  public Guid TeacherId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Mobile { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
  public required SubjectName Subject { get; set; }
}
