using System.Text.Json;
using Lowes.CustomerManagement.Exceptions;

namespace Lowes.CustomerManagement.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(
        RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(CustomerAlreadyExistsException ex)
        {
            context.Response.StatusCode = 409;
            context.Response.ContentType =
                "application/json";

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(
                    new
                    {
                        message = ex.Message
                    }));
        }
        catch(Exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType =
                "application/json";

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(
                    new
                    {
                        message =
                        "An unexpected error occurred"
                    }));
        }
    }
}