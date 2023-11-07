using ListaDeTarefas.Application.Responses;

namespace ListaDeTarefas.Application.UseCases.GetByIdTarefa
{
    public interface IGetByIdTarefaUseCase
    {
        Task<GetByIdTarefaResponse> Execute(int id, string email, CancellationToken cancellationToken);
    }
}
