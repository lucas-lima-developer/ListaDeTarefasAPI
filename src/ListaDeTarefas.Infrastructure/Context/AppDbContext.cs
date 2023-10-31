using ListaDeTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
