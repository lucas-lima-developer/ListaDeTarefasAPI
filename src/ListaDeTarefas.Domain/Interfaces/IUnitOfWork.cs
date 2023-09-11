namespace ListaDeTarefas.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
