using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.HttpFilters
{
    public class ResponseFilter : IResultFilter
    {
        private readonly ILogger<ResponseFilter> _logger;

        public ResponseFilter(ILogger<ResponseFilter> logger)
        {
            _logger = logger;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var result = context.Result;
            _logger.LogCritical("result: {@result}", result);
            var cookies = context.HttpContext.Response.Cookies;
            _logger.LogCritical("cookies: {@cookies}", cookies);
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result;
            _logger.LogCritical("result: {@result}", result);
            var cookies = context.HttpContext.Response.Cookies;
            _logger.LogCritical("cookies: {@cookies}", cookies);
        }
    }
}
