using ListaDeTarefas.Domain.Enum;

namespace ListaDeTarefas.Domain.Entities
{
    public class Tarefa : EntidadeBase
    {
        public string? Titulo { get; set; }
        public string? Descricao { get;  set; }
        public DateTime? DataConclusao { get; set; }
        public Prioridade prioridade { get; set; }
    }
}
