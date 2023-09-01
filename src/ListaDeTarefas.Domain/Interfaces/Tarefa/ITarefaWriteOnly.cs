namespace ListaDeTarefas.Domain.Interfaces.Tarefa
{
    public interface ITarefaWriteOnly
    {
        Task Registrar(Entidades.Tarefa tarefa);
        Task Deletar(long tarefaId);
    }
}
