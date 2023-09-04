using ListaDeTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Infrastructure.Repositorios
{
    public class ListaDeTarefasContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public ListaDeTarefasContext(DbContextOptions<ListaDeTarefasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListaDeTarefasContext).Assembly);
        }
    }
}
