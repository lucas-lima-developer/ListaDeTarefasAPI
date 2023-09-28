using ListaDeTarefas.Domain.Enum;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll
{
    public class GetAllTarefaResponse
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LimitDate { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletionDate { get; set; }
        public DateTime DateCreated { get; set; } 
        public DateTime DateUpdated { get; set; } 
    }
}