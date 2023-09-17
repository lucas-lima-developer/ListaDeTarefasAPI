using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Update
{
    public interface IUpdateTearefaUseCase
    {
        Task Execute(long id, Tarefa tarefa);
    }
}
