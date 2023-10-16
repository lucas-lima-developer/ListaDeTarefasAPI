using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;
using MediatR;

namespace ListaDeTarefas.Application.UseCases.GetByIdTarefa
{
    public class GetByIdTarefaHandler : IRequestHandler<GetByIdTarefaRequest, GetByIdTarefaResponse>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public GetByIdTarefaHandler(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTarefaResponse> Handle(GetByIdTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetById(request.Id, cancellationToken);

            if (tarefa == null) throw new TarefaNotFoundException(request.Id);
            
            return _mapper.Map<GetByIdTarefaResponse>(tarefa);
        }
    }

    public sealed record GetByIdTarefaRequest(long Id) : IRequest<GetByIdTarefaResponse>;

    public class GetByIdTarefaResponse
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LimitDate { get; set; }
        public string? Priority { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public sealed class GetByIdTarefaMapper : Profile
    {
        public GetByIdTarefaMapper()
        {
            CreateMap<Tarefa, GetByIdTarefaResponse>();
        }
    }

    public class GetByIdTarefaValidator : AbstractValidator<GetByIdTarefaRequest>
    {
        public GetByIdTarefaValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.ID_EMPTY)
                .GreaterThanOrEqualTo(1).WithMessage(Exceptions.Resources.ErrorMessages.ID_GREATER_THAN_0);
        }
    }
}
