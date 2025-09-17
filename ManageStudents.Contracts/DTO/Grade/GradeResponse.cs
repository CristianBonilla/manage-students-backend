using ManageStudents.Contracts.DTO.Base;

namespace ManageStudents.Contracts.DTO.Grade;

public class GradeResponse : Auditable
{
  public Guid GradeId { get; set; }
  public required Guid TeacherId { get; set; }
  public required Guid StudentId { get; set; }
  public required float Value { get; set; }
}
