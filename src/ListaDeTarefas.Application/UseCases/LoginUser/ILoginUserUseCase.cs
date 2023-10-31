namespace ListaDeTarefas.Application.UseCases.LoginUser
{
    public interface ILoginUserUseCase
    {
        Task<LoginUserResponse> Execute(LoginUserRequest request, CancellationToken cancellationToken);
    }
}
