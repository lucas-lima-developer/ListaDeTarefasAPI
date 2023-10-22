using AutoMapper;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.CreateTarefa
{
    public class CreateTarefaUseCase : ICreateTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTarefaUseCase(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateTarefaResponse> Execute(CreateTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefa = _mapper.Map<Tarefa>(request);

            _tarefaRepository.Create(tarefa);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateTarefaResponse>(tarefa);
        }
    }
}
