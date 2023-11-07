using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Domain.Interfaces
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        Task<List<Tarefa>> GetAll(User user, CancellationToken cancellationToken);
        Task<Tarefa?> GetById(User user, long id, CancellationToken cancellationToken);
    }
}
