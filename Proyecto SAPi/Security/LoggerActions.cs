using Service.Services.Contract;
using System.Diagnostics;
using System.Security.Claims;

namespace Proyecto_SAPi.Security
{
    public class LoggerActions
    {

        private readonly RequestDelegate _next;

        public LoggerActions(RequestDelegate next)
        {
            _next = next;
        }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public async Task InvokeAsync(HttpContext context, ILogger<LoggerActions> logger)
        {

            try
            {
                var request = context.Request;
                var user = context.User.Identity.IsAuthenticated ? context.User.Identity.Name : "Anonymous";
                var claimId = context.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier);

                logger.LogInformation($"Request {context.TraceIdentifier}, User: {user}, Method: {request.Method}, Path: {request.Path}");

                await _next(context);

                var response = context.Response;

                logger.LogInformation($"Request {context.TraceIdentifier}, Response: Status Code: {response.StatusCode}");

            }
            catch (Exception ex)
            {
                logger.LogError($"Request Error {context.TraceIdentifier}, Message: {ex.Message}");
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
