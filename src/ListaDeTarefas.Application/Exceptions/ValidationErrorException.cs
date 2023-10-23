using FluentValidation.Results;

namespace ListaDeTarefas.Application.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException(string message) : base(message) { }

        public ValidationErrorException(ValidationResult result) : base(result.ToString(" ")) { }
    }
}
