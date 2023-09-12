using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Infrastructure.Context;

namespace ListaDeTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context) : base(context) { }
    }
}
