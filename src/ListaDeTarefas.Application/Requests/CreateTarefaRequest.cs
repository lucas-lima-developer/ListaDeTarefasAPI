namespace ListaDeTarefas.Application.Requests
{
    public sealed class CreateTarefaRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
