namespace ListaDeTarefas.Application.Exceptions
{
    public class TarefaNotFoundException : Exception
    {
        private long TarefaId { get; }

        public TarefaNotFoundException(long tarefaId) : base($"A tarefa com ID = {tarefaId} não foi encontrada.") 
        {
            TarefaId = tarefaId;
        }

        public TarefaNotFoundException(string message) : base(message) { }
    }
}
