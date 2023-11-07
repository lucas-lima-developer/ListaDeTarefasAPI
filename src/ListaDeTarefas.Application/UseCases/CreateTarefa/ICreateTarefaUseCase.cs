using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;

namespace ListaDeTarefas.Application.UseCases.CreateTarefa
{
    public interface ICreateTarefaUseCase
    {
        Task<CreateTarefaResponse> Execute(CreateTarefaRequest request, string emailUser, CancellationToken cancellationToken);
    }
}
