using ListaDeTarefas.Application.Responses;

namespace ListaDeTarefas.Application.UseCases.DeleteTarefa
{
    public interface IDeleteTarefaUseCase
    {
        public Task<DeleteTarefaResponse> Execute(int id, string email, CancellationToken cancellationToken);
    }
}
