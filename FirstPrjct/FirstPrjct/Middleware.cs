using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Ent;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace FirstPrjct
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        //Rating rating = new Rating();
        IRatingBL ratingBL;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingBL _ratingBL)
        {
            ratingBL = _ratingBL;
            Rating rating = new Rating();
            rating.Method = httpContext.Request.Method.ToString();
            rating.Path = httpContext.Request.Path.ToString();
            rating.RecordDate = DateTime.Now;
            rating.UserAgent = httpContext.Request.Headers["User-Agent"].ToString();
            rating.Host = httpContext.Request.Host.Value.ToString();
            rating.Referer = httpContext.Request.Headers["Referer"].ToString();

            ratingBL.insertRating(rating);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
