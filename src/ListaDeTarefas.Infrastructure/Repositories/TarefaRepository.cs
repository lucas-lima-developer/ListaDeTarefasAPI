using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Tarefa>> GetAll(User user, CancellationToken cancellationToken)
        {
            return await _context.Tarefas.Where(tarefa => tarefa.User == user).ToListAsync(cancellationToken);
        }

        public async Task<Tarefa?> GetById(User user, long id, CancellationToken cancellationToken)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(tarefa => tarefa.User == user && tarefa.Id == id, cancellationToken);
        }
    }
}
