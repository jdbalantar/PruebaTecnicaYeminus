using EncryptionSoftware.Application.ErrorHandler;
using Newtonsoft.Json;

namespace EncryptionSoftware.Rest.Middleware
{
    public class MiddlewareErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareErrorHandler> _logger;

        public MiddlewareErrorHandler(RequestDelegate next, ILogger<MiddlewareErrorHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await AsynchronousExceptionHandler(context, e, _logger);
            }
        }

        private static async Task AsynchronousExceptionHandler(HttpContext context, Exception ex,
            ILogger logger)
        {
            object errors = null;

            switch (ex)
            {
                case RestException me:
                    logger.LogError(ex, "Error Handler");
                    errors = me.Errors;
                    context.Response.StatusCode = (int)me.Code;
                    break;
                case not null:
                    logger.LogError(ex, "Internal Server Error");
                    errors = string.IsNullOrWhiteSpace(ex.Message) ? "Error" : ex.Message;
                    break;
            }

            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var results = JsonConvert.SerializeObject(new { errors });
                await context.Response.WriteAsync(results);
            }
        }
    }
}