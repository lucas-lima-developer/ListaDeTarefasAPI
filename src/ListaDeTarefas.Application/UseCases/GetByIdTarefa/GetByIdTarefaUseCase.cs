using AutoMapper;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.GetByIdTarefa
{
    public class GetByIdTarefaUseCase : IGetByIdTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public GetByIdTarefaUseCase(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTarefaResponse> Execute(int id, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetById(id, cancellationToken);

            if (tarefa == null) throw new TarefaNotFoundException(id);

            return _mapper.Map<GetByIdTarefaResponse>(tarefa);
        }
    }
}
