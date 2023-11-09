using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using midis.muchik.market.crosscutting.models;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace midis.muchik.market.api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);

            if(httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                httpContext.Response.ContentType = "application/json";
                var response = httpContext.Response;
                var genericResponse = new GenericResponse<object>("Se necesita una autenticación para acceder al recurso.");

                var genericResponseJson = JsonSerializer.Serialize(genericResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                await httpContext.Response.WriteAsync(genericResponseJson);
            }

            if (httpContext.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                httpContext.Response.ContentType = "application/json";
                var response = httpContext.Response;
                var genericResponse = new GenericResponse<object>("No tienes permiso para acceder a este recurso.");

                var genericResponseJson = JsonSerializer.Serialize(genericResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                await httpContext.Response.WriteAsync(genericResponseJson);
            }
        }
    }
}
