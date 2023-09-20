using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete
{
    public interface IDeleteTarefaUseCase
    {
        Task<Tarefa> Execute(long tarefaId);
    }
}
