using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Infrastructure.Repositories;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Add
{
    public class AddTarefaUseCase : IAddTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddTarefaUseCase(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Tarefa novaTarefa)
        {
            _tarefaRepository.Create(novaTarefa);
            await _unitOfWork.Commit();
        }
    }
}
