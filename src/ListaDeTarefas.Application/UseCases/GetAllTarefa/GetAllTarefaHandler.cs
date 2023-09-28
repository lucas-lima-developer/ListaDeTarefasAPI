using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Enum;
using ListaDeTarefas.Domain.Interfaces;
using MediatR;

namespace ListaDeTarefas.Application.UseCases.GetAllTarefa
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

    public sealed record class GetAllTarefaRequest : IRequest<List<GetAllTarefaResponse>>
    {
    }

    public class GetAllTarefaResponse
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LimitDate { get; set; }
        public Priority? Priority { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public sealed class GetAllTarefaMapper : Profile
    {
        public GetAllTarefaMapper()
        {
            CreateMap<Tarefa, GetAllTarefaResponse>();
        }
    }

    public class GetAllTarefaValidator : AbstractValidator<GetAllTarefaRequest>
    {
        public GetAllTarefaValidator() { }
    }
}
