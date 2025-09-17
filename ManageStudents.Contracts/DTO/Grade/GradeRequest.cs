namespace ManageStudents.Contracts.DTO.Grade;

public class GradeRequest
{
  public required Guid TeacherId { get; set; }
  public required Guid StudentId { get; set; }
  public required float Value { get; set; }
}
