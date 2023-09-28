namespace ListaDeTarefas.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Commit(CancellationToken cancellationToken);
    }
}
