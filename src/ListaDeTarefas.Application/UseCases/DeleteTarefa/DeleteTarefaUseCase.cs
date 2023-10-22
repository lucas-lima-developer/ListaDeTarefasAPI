using AutoMapper;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.DeleteTarefa
{
    public class DeleteTarefaUseCase : IDeleteTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTarefaUseCase(IUnitOfWork unitOfWork, ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteTarefaResponse> Execute(int id, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetById(id, cancellationToken);

            if (tarefa == null) throw new TarefaNotFoundException(id);

            _tarefaRepository.Delete(tarefa);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteTarefaResponse>(tarefa);
        }
    }
}
