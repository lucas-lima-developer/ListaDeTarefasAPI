using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ListaDeTarefas.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;

        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTime.Now;
            Context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTime.Now;
            Context.Update(entity);
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
        }

        public async Task<T> Get(long id)
        {
            var t = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            if (t == null)
            {
                throw new Exception("entidade não encontrada");
            }

            return t;
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync();
        }

    }
}
