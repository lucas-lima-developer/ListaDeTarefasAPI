namespace ListaDeTarefas.Application.UseCases.CreateUser
{
    public interface ICreateUserUseCase
    {
        Task<CreateUserResponse> Execute(CreateUserRequest request, CancellationToken cancellationToken);
    }
}
