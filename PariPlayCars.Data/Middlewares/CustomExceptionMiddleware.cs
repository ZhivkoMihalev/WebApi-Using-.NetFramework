namespace PariPlayCars.Data.Middlewares
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using PariPlayCars.Data.ApplicationExceptions;

    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this._next(context);
            }

            catch (EntityAlreadyExistsException exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsync(exception.Message);
            }

            catch (EntityNotFoundException exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsync(exception.Message);
            }

            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync("Server error.");
            }
        }
    }
}
