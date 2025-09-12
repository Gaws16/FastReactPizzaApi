using FastReactPizzaApi.Dtos;

namespace FastReactPizzaApi.Middleware;

public class ExceptionHandlingMiddleware
{
    public readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlingMiddleware> logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            
            logger.LogError(e, e.Message );
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            
            var response = ApiResponse<string>.Fail("Unhandled exception");
            await context.Response.WriteAsJsonAsync(response);
            
        }
    }
}