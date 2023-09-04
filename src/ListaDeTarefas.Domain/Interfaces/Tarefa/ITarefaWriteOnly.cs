namespace ListaDeTarefas.Domain.Interfaces.Tarefa
{
    public interface ITarefaWriteOnly
    {
        Task Registrar(Entities.Tarefa tarefa);
        Task Deletar(long tarefaId);
    }
}
