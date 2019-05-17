using BuildingBlocks.Security.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Extensions.Security
{
    public static class SecurityMiddlewareExtensions
    {
        public static IApplicationBuilder UseAccessControl(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecurityMiddleware>();
            return app;
        }
    }
}
