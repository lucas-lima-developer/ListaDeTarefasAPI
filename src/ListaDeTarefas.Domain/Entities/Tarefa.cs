using ListaDeTarefas.Domain.Enum;

namespace ListaDeTarefas.Domain.Entities
{
    public class Tarefa : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get;  set; }
        public DateTimeOffset? CompletionDate { get; set; }
        public Priority Priority { get; set; }
    }
}
