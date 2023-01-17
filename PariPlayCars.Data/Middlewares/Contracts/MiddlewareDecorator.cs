namespace PariPlayCars.Data.Middlewares.Contracts
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class MiddlewareDecorator : Middleware
    {
        protected Middleware _middleware;

        public MiddlewareDecorator(Middleware middleware)
        {
            this._middleware = middleware;
        }

        public override Task InvokeAsync(HttpContext context)
        {
            return this._middleware.InvokeAsync(context);
        }
    }
}
