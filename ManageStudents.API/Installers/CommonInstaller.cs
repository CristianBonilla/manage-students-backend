using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ManageStudents.API.Filters;
using ManageStudents.API.Utils;

namespace ManageStudents.API.Installers;

class CommonInstaller : IInstaller
{
  public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
  {
    services.AddMvc(options => options.Filters.Add<ServiceErrorExceptionFilterAttribute>());
    services.AddControllers()
      .AddNewtonsoftJson(JsonSerializer);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    // services.AddEndpointsApiExplorer();
    services.AddApiVersioning(options =>
    {
      options.DefaultApiVersion = new ApiVersion(1, 0);
      options.AssumeDefaultVersionWhenUnspecified = true;
      options.ReportApiVersions = true;
    }).AddApiExplorer(options =>
    {
      options.GroupNameFormat = "'v'VVV";
      options.SubstituteApiVersionInUrl = true;
    });
    services.AddRouting(options => options.LowercaseUrls = true);
    // Another alternative - services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    services.AddCors(options =>
    {
      options.AddPolicy(ApiConfigKeys.AllowOrigins, builder =>
      {
        builder.WithOrigins("http://localhost:14988", "https://localhost:14989")
          .AllowAnyHeader()
          .WithMethods("GET", "POST", "PUT", "DELETE", "PATCH");
      });
    });
  }

  private void JsonSerializer(MvcNewtonsoftJsonOptions options)
  {
    JsonSerializerSettings settings = options.SerializerSettings;
    settings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
    settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    settings.Formatting = Formatting.None;
  }
}
