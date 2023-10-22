namespace ListaDeTarefas.Application.UseCases.CreateTarefa
{
    public sealed class CreateTarefaRequest 
    { 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime LimitDate { get; set; }
        public string? Priority { get; set; }
    }
}
