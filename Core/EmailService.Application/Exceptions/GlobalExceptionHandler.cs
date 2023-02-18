using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Application.Exceptions
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;

        public GlobalExceptionHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch ( Exception ex)
            {

                HandlingException(context, ex);
            }
        }
        private async Task HandlingException(HttpContext context,Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new Error()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }));

        }
        public class Error
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }

        }
    }
}
