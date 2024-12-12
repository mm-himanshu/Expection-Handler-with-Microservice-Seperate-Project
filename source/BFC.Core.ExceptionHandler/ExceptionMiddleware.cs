namespace ExceptionHandler
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BaseException ex)
            {
                await ex.HandleAPIException(_logger, httpContext);
            }
            catch (Exception ex)
            {
                await ex.HandleAPIException(_logger, httpContext);
            }
        }
    }
}