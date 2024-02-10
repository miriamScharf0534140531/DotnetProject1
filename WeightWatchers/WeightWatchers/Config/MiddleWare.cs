using Newtonsoft.Json;

namespace WeightWatchers.Config
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            _logger=logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm");
                _logger.LogDebug($"start cell api {context.Request.Path} start in {time} ");
                await next(context);
                string time2 = DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm");
                _logger.LogInformation($"end  cell api {context.Request.Path} start in {time2} ");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = JsonConvert.SerializeObject(new { error = ex.Message });         
            return context.Response.WriteAsync(result);
        }
    }
}
