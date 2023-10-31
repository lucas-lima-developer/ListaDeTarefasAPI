namespace ListaDeTarefas.Application.UseCases.CreateUser
{
    public class CreateUserResponse
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
