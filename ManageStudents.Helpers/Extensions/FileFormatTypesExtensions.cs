using ManageStudents.Contracts.Enums;

namespace ManageStudents.Helpers.Extensions;

public static class FileFormatTypesExtensions
{
  static readonly Dictionary<FileFormatType, string> _formatTypes = new()
  {
    { FileFormatType.PlainText, ".txt" },
    { FileFormatType.Xml, ".xml" }
  };

  public static string GetFormatType(this FileFormatType formatType) => _formatTypes.GetValueOrDefault(formatType) ?? Enum.GetName(formatType)!;
}
