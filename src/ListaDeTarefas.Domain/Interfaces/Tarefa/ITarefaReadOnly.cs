namespace ListaDeTarefas.Domain.Interfaces.Tarefa
{
    public interface ITarefaReadOnly
    {
        Task<Entities.Tarefa> RecuperarPorId(long tarefaId);
    }
}
