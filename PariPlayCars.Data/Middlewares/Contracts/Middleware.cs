namespace PariPlayCars.Data.Middlewares.Contracts
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public abstract class Middleware
    {
        public Middleware()
        {
        }

        public abstract Task InvokeAsync(HttpContext context);
    }
}
