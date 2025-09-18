using ManageStudents.Contracts.Enums;

namespace ManageStudents.API.Utils;

record struct ApiConfigKeys
{
  public const string AllowOrigins = nameof(AllowOrigins);
  public const string Bearer = nameof(Bearer);
  public const string DatabaseName = nameof(DatabaseName);
  public const string LocalConnection = nameof(LocalConnection);
  public const string DockerConnection = nameof(DockerConnection);
  public const string DockerComposeConnection = nameof(DockerComposeConnection);

  static readonly Dictionary<ProcessType, string> _processTypes = new()
  {
    { ProcessType.Local, LocalConnection },
    { ProcessType.IISExpress, LocalConnection },
    { ProcessType.Docker, DockerConnection },
    { ProcessType.DockerCompose, DockerComposeConnection }
  };

  public static ProcessType ProcessType
  {
    get
    {
      string processTypeValue = Environment.GetEnvironmentVariable("PROCESS_TYPE") switch
      {
        null => nameof(ProcessType.Local),
        string source when string.Equals(source, "iis-express", StringComparison.OrdinalIgnoreCase) => nameof(ProcessType.IISExpress),
        string source when string.Equals(source, "docker-compose", StringComparison.OrdinalIgnoreCase) => nameof(ProcessType.DockerCompose),
        string source => source
      };

      return Enum.TryParse(processTypeValue, true, out ProcessType processType) ? processType : ProcessType.Local;
    }
  }

  public static string GetConnectionKeyFromProcessType() => _processTypes.GetValueOrDefault(ProcessType) ?? throw new KeyNotFoundException("Process type not found to get connection key");
}
