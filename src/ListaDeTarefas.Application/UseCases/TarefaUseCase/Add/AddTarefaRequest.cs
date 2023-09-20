using ListaDeTarefas.Domain.Enum;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Add
{
    public class AddTarefaRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LimitDate { get; set; }
        public Priority Priority { get; set; }
    }
}
