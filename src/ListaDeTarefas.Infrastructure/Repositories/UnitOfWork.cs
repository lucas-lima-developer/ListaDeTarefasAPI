using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Infrastructure.Context;

namespace ListaDeTarefas.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) 
        {
            _context = context;
        }

        public async Task Commit()
        {
             await _context.SaveChangesAsync();
        }
    }
}
