using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetById
{
    public interface IGetByIdTarefaUseCase 
    {
        Task<Tarefa> Execute(long id);
    }
}
