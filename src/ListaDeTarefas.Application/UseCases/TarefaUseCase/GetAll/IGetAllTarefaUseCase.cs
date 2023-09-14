using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll
{
    public interface IGetAllTarefaUseCase
    {
        Task<List<Tarefa>> Execute();
    }
}
