using ListaDeTarefas.API.Contracts;
using ListaDeTarefas.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ListaDeTarefas.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Error error;
            if (context.Exception is ValidationErrorException)
            {
                error = new Error
                {
                    StatusCode = "400",
                    Message = context.Exception.Message,
                };

                context.Result = new JsonResult(error) { StatusCode = 400 };
            }
            else if (context.Exception is TarefaNotFoundException)
            {
                error = new Error
                {
                    StatusCode = "404",
                    Message = context.Exception.Message,
                };

                context.Result = new JsonResult(error) { StatusCode = 404 };
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
