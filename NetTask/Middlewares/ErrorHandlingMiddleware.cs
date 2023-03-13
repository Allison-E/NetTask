using System.Text.Json;
using NetTask.Application.Exceptions;
using ValidationException = NetTask.Application.Exceptions.ValidationException;

namespace NetTask.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        var errorResponse = new ErrorResponse();

        try
        {
            await _next(context);
        }
        catch (NotFoundException e)
        {
            _logger.LogWarning(e, e.Message);
            response.StatusCode = StatusCodes.Status404NotFound;
            errorResponse.Message = e.Message;
        }
        catch (NotImplementedException e)
        {
            _logger.LogError(e, e.Message);
            response.StatusCode = StatusCodes.Status501NotImplemented;
            errorResponse.Message = e.Message;
        }
        catch (ValidationException e)
        {
            _logger.LogError(e, e.Message);
            response.StatusCode = StatusCodes.Status400BadRequest;
            errorResponse.Message = e.Message;
            errorResponse.Errors = e.Errors;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            response.StatusCode = StatusCodes.Status500InternalServerError;
            errorResponse.Message = "An error occurred.";
        }
        finally
        {
            if (!response.HasStarted)
            {
                errorResponse.Status = response.StatusCode;

                var result = JsonSerializer.Serialize(errorResponse);

                await response.WriteAsync(result);
            }
        }
    }
}
