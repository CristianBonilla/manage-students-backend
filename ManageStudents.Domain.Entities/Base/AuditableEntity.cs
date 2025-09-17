namespace ManageStudents.Domain.Entities.Base;

public abstract class AuditableEntity
{
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset UpdatedAt { get; set; }
  public byte[] Version { get; set; } = null!;
}
