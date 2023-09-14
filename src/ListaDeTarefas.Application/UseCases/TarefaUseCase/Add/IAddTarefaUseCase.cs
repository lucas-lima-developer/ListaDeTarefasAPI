using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Add
{
    public interface IAddTarefaUseCase
    {
        Task<Tarefa> Execute(Tarefa newTarefa);
    }
}
