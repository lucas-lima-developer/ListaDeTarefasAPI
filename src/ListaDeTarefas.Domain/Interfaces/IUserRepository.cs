using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
