using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Teledock.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var responce = new
            {
                Message = "An error occurred while processing your request.",
                ExceptionMessage = exception.Message,
                ExceptionType = exception.GetType().Name,
            };
            context.Result = new ObjectResult(responce)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
