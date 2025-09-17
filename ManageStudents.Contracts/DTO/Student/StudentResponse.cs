using ManageStudents.Contracts.DTO.Base;

namespace ManageStudents.Contracts.DTO.Student;

public class StudentResponse : Auditable
{
  public Guid StudentId { get; set; }
  public required string DocumentNumber { get; set; }
  public required string Mobile { get; set; }
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }
  public required string Email { get; set; }
}
