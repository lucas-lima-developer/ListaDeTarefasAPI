namespace ListaDeTarefas.Application.Exceptions
{
    public class WrongCredentialsException : Exception
    {
        public WrongCredentialsException() : base(Exceptions.Resources.ErrorMessages.USER_WRONG_CREDENTIALS) { }
    }
}
