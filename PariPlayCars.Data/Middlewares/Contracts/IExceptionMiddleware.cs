using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PariPlayCars.Data.Middlewares.Contracts
{
    public interface IExceptionMiddleware
    {
        Task InvokeAsync(HttpContext context);
    }
}
