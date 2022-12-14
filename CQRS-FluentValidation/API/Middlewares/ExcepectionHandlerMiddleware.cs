using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExcepectionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExcepectionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (FluentValidation.ValidationException ex)
            {
                httpContext.Response.StatusCode = 400;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(ex));
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(ex));
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExcepectionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExcepectionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExcepectionHandlerMiddleware>();
        }
    }
}
