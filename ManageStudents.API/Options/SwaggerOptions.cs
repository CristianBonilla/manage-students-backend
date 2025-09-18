using Microsoft.OpenApi.Models;

namespace ManageStudents.API.Options;

class SwaggerOptions
{
  public required string JsonRoute { get; set; }
  public required string UIEndpoint { get; set; }
  public required OpenApiInfo Info { get; set; }
  public OpenApiSecurityScheme? SecurityScheme { get; set; }
}
