using Microsoft.Data.SqlClient;
using midis.muchik.market.crosscutting.exceptions;
using midis.muchik.market.crosscutting.models;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace midis.muchik.market.api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try {
                await _next(httpContext);
            } catch (Exception ex){
                await HandleException(httpContext, ex);
            }
            
        }

        private async Task HandleException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            
            var genericResponse = new GenericResponse<object>("");

            switch(exception)
            {
                case MuchikException ex:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    genericResponse.Message = ex.Message;
                    break;
                case SqlException ex:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    genericResponse.Message = "Ocurrió un error con la base de datos, vuelva a intentar en unos minutos.";
                    break;
                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    genericResponse.Message = "Ocurrió un error con la aplicación, vuelva a intentar en unos minutos.";
                    break;
            }

            var genericResponseJson = JsonSerializer.Serialize(genericResponse);
            await httpContext.Response.WriteAsync(genericResponseJson);

        }
    }


}
