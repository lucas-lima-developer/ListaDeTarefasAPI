using MediatR;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll
{
    public sealed record class GetAllTarefaRequest : IRequest<List<GetAllTarefaResponse>>
    {
    }
}
