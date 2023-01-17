namespace PariPlayCars.Data.Middlewares
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using PariPlayCars.Data.ApplicationExceptions;
    using PariPlayCars.Data.Middlewares.Contracts;

    public class CustomExceptionMiddleware : Middleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
            //:base(next)
        {
            this._next = next;
        }

        public override async Task InvokeAsync(HttpContext context)
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
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;

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
