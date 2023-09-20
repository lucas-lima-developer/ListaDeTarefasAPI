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

        public async Task<Tarefa> Execute(AddTarefaRequest requestNewTarefa)
        {
            var newTarefa = ConvertRequest(requestNewTarefa);

            _tarefaRepository.Create(newTarefa);
            await _unitOfWork.Commit();

            return newTarefa;
        }

        public static Tarefa ConvertRequest(AddTarefaRequest requestNewTarefa)
        {
            var newTarefa = new Tarefa();
            newTarefa.Title = requestNewTarefa.Title;
            newTarefa.Description = requestNewTarefa.Description;
            newTarefa.Priority = requestNewTarefa.Priority;
            newTarefa.LimitDate = requestNewTarefa.LimitDate;

            return newTarefa;
        }
    }
}
