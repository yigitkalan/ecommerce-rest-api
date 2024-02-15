using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace Ecommerce.Application.Exceptions;
public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next.Invoke(httpContext);

        }
        catch (System.Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        int statusCode = GetStatusCode(exception);
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        var response = new ExceptionModel
        {
            StatusCode = statusCode,
            Errors = new List<string>() { $"Error Message : {exception.Message}"
            , $"Message Explanation: {exception.InnerException?.Message}" }
        };

        return httpContext.Response.WriteAsync(response.ToString());

    }

    public static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}