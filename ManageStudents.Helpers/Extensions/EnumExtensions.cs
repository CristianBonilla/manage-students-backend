using System.ComponentModel;
using System.Reflection;

namespace ManageStudents.Helpers.Extensions;

public static class EnumExtensions
{
  public static string GetDescription(this Enum source)
  {
    FieldInfo? field = source.GetType().GetField(source.ToString());
    DescriptionAttribute? descriptionAttribute = field?.GetCustomAttribute<DescriptionAttribute>();

    return descriptionAttribute?.Description ?? source.ToString();
  }
}
