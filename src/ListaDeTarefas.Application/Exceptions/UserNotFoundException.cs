namespace ListaDeTarefas.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base(Exceptions.Resources.ErrorMessages.USER_NOT_FOUND) { }
    }
}
