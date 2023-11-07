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
            Error error = new Error(context.Exception.Message);
            var exception = context.Exception;

            if (exception is ValidationErrorException || exception is WrongCredentialsException)
            {
                error.StatusCode = "400";
                context.Result = new JsonResult(error) { StatusCode = 400 };
            }
            else if (exception is TarefaNotFoundException || exception is UserNotFoundException)
            {
                error.StatusCode = "404";
                context.Result = new JsonResult(error) { StatusCode = 404 };
            }
            else
            {
                error.StatusCode = "500";
                context.Result = new JsonResult(error) { StatusCode = 500 };
            }
        }
    }
}
