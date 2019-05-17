using BuildingBlocks.Security.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Middleware
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ISecurityManager manager)
        {
            var user = context.User;
            manager.HttpContext = context;

            await _next.Invoke(context);
        }
    }
}
