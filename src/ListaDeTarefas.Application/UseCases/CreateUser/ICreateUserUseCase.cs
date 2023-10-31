using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;

namespace ListaDeTarefas.Application.UseCases.CreateUser
{
    public interface ICreateUserUseCase
    {
        Task<CreateUserResponse> Execute(CreateUserRequest request, CancellationToken cancellationToken);
    }
}
