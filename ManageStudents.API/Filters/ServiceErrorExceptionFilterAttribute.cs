using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ManageStudents.Contracts.DTO;
using ManageStudents.Contracts.Exceptions;

namespace ManageStudents.API.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
class ServiceErrorExceptionFilterAttribute : ExceptionFilterAttribute
{
  public override void OnException(ExceptionContext context)
  {
    if (context.Exception is ServiceErrorException exception)
    {
      ServiceError serviceError = exception.ServiceError;
      context.Result = new ObjectResult(serviceError)
      {
        ContentTypes = ["application/json"],
        StatusCode = serviceError.StatusCode
      };
      context.ExceptionHandled = true;
    }
  }
}
