using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Complete
{
    public class CompleteTarefaUseCase : ICompleteTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompleteTarefaUseCase(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            var tarefa = await _tarefaRepository.Get(id);
            if (tarefa != null)
            {
                tarefa.IsCompleted = true;
                _tarefaRepository.Update(tarefa);
                await _unitOfWork.Commit();
            }
        }
    }
}
