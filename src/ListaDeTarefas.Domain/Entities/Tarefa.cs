using System.ComponentModel.DataAnnotations.Schema;

namespace ListaDeTarefas.Domain.Entities
{

    [Table("Tarefas")]
    public class Tarefa : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get;  set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletionDate { get; set; }
    }
}
