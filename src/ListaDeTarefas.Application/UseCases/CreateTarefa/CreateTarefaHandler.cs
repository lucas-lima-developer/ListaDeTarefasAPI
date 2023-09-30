using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Enum;
using ListaDeTarefas.Domain.Interfaces;
using MediatR;

namespace ListaDeTarefas.Application.UseCases.CreateTarefa
{
    public sealed class CreateTarefaHandler : IRequestHandler<CreateTarefaRequest, CreateTarefaResponse>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTarefaHandler(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateTarefaResponse> Handle(CreateTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefa = _mapper.Map<Tarefa>(request);

            _tarefaRepository.Create(tarefa);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateTarefaResponse>(tarefa);
        }
    }

    public sealed record CreateTarefaRequest(string Title, string Description, DateTime LimiteDate, Priority Priority) : IRequest<CreateTarefaResponse>;

    public class CreateTarefaResponse
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

    public sealed class CreateTarefaMapper : Profile
    {
        public CreateTarefaMapper() 
        {
            CreateMap<CreateTarefaRequest, Tarefa>();
            CreateMap<Tarefa, CreateTarefaResponse>();
        }
    }

    public sealed class CreateTarefaValidator : AbstractValidator<CreateTarefaRequest>
    {
        public CreateTarefaValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(150);
            RuleFor(x => x.LimiteDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Priority).NotNull();
        }
    }
}
