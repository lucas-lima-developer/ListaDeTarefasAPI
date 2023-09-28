using AutoMapper;
using ListaDeTarefas.Domain.Interfaces;
using MediatR;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll
{
    public sealed class GetAllTarefaHandler : IRequestHandler<GetAllTarefaRequest, List<GetAllTarefaResponse>>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public GetAllTarefaHandler(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllTarefaResponse>> Handle(GetAllTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefas = await _tarefaRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllTarefaResponse>>(tarefas);
        }
    }
}
