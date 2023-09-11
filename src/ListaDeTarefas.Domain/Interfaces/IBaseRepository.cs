using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(long id);
        Task<List<T>> GetAll();

    }
}
