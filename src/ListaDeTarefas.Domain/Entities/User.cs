namespace ListaDeTarefas.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<Tarefa>? Tarefas { get; set; }
    }
}
