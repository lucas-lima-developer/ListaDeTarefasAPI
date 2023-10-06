using System.Text.Json;

namespace ListaDeTarefas.API.Contracts
{
    public class Error
    {
        public string? StatusCode { get; set; }
        public string? Message { get; set; }

        public Error(string? message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
