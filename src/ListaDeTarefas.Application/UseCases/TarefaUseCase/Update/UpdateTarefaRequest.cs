using ListaDeTarefas.Domain.Enum;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Update
{
    public class UpdateTarefaRequest
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LimitDate { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
