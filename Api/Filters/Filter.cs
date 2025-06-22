using App.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Api.Filters;

public class HttpExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is HttpException httpEx)
        {
            context.Result = new ObjectResult(new { error = httpEx.Message })
            {
                StatusCode = httpEx.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}
