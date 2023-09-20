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
        public async Task<Tarefa> Execute(UpdateTarefaRequest updatedTarefaRequest)
        {
            var tarefaExistente = await _tarefaRepository.Get(updatedTarefaRequest.Id);

            if (tarefaExistente != null)
            {
                tarefaExistente.Title = updatedTarefaRequest.Title;
                tarefaExistente.Description = updatedTarefaRequest.Description;
                tarefaExistente.Priority = updatedTarefaRequest.Priority;
                
                _tarefaRepository.Update(tarefaExistente);
                await _unitOfWork.Commit();
            }

            return tarefaExistente!;
        }
    }
}
