namespace ListaDeTarefas.Domain.Interfaces.Tarefa
{
    public interface ITarefaReadOnly
    {
        Task<Entidades.Tarefa> RecuperarPorId(long tarefaId);
    }
}
