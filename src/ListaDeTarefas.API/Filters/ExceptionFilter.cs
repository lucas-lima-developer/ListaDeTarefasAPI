using ListaDeTarefas.API.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ListaDeTarefas.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Error error;
            if (context.Exception is FluentValidation.ValidationException)
            {
                error = new Error
                {
                    StatusCode = "400",
                    Message = context.Exception.Message,
                };

                context.Result = new JsonResult(error) { StatusCode = 400 };
            }
            else
            {
                error = new Error
                {
                    StatusCode = "500",
                    Message = context.Exception.Message,
                };

                context.Result = new JsonResult(error) { StatusCode = 500 };
            }
        }
    }
}
