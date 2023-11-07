namespace ListaDeTarefas.Application.Exceptions
{
    public class TarefaNotFoundException : Exception
    {
        public TarefaNotFoundException() : base(Exceptions.Resources.ErrorMessages.TAREFA_NOT_FOUND) { }
    }
}
