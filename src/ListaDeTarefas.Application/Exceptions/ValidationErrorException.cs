namespace ListaDeTarefas.Application.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public IEnumerable<string>? Errors {  get; }

        public ValidationErrorException(IEnumerable<string> errors) : base(BuildMessage(errors))
        {
            Errors = errors;
        }

        public ValidationErrorException(string message) : base(message) { }

        private static string BuildMessage(IEnumerable<string> errors)
        {
            return string.Join(" || ", errors);
        }
    }
}
