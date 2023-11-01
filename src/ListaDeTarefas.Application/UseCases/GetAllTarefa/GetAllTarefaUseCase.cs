using AutoMapper;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.GetAllTarefa
{
    public class GetAllTarefaUseCase : IGetAllTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public GetAllTarefaUseCase(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllTarefaResponse>> Execute(CancellationToken cancellationToken)
        {
            var tarefas = await _tarefaRepository.GetAll(cancellationToken);

            if (tarefas.Count == 0) throw new TarefaNotFoundException("Nenhuma tarefa encontrada.");

            return _mapper.Map<List<GetAllTarefaResponse>>(tarefas);
        }
    }
}
