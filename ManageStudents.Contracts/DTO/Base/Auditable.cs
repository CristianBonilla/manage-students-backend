namespace ManageStudents.Contracts.DTO.Base;

public class Auditable
{
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
}
