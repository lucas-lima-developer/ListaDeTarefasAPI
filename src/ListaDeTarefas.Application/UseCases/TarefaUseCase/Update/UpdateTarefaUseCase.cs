using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Update
{
    public class UpdateTarefaUseCase : IUpdateTearefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTarefaUseCase(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(long id, Tarefa updatedTarefa)
        {
            var tarefaExistente = await _tarefaRepository.Get(id);

            if (tarefaExistente != null)
            {
                tarefaExistente.Title = updatedTarefa.Title;
                tarefaExistente.Description = updatedTarefa.Description;
                tarefaExistente.Priority = updatedTarefa.Priority;
                
                _tarefaRepository.Update(tarefaExistente);
                await _unitOfWork.Commit();
            }
        }
    }
}
