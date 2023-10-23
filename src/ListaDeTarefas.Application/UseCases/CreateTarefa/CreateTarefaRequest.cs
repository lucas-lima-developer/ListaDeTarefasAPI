namespace ListaDeTarefas.Application.UseCases.CreateTarefa
{
    public sealed class CreateTarefaRequest 
    { 
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
