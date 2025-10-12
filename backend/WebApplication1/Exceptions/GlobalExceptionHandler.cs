using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication1.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if (exception is InvalidOperationException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                await httpContext.Response.WriteAsJsonAsync(exception.Message, cancellationToken);
               
                return true;
            }
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync("An unexpected error occurred.", cancellationToken);

            return true;
        }
    }
}
