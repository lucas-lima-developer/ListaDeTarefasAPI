using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Application.Helpers;
using ListaDeTarefas.Domain.Entities;
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

    public sealed record CreateTarefaRequest(string Title, string Description, DateTime LimitDate, string Priority) : IRequest<CreateTarefaResponse>;

    public class CreateTarefaResponse
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
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.TITLE_NOT_EMPTY)
                .MaximumLength(50).WithMessage(Exceptions.Resources.ErrorMessages.TITLE_MAX_LENGTH);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.DESCRIPTION_NOT_EMPTY)
                .MaximumLength(150).WithMessage(Exceptions.Resources.ErrorMessages.DESCRIPTION_MAX_LENGTH);

            RuleFor(x => x.LimitDate)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.LIMITDATE_NOT_EMPTY)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage(Exceptions.Resources.ErrorMessages.LIMITDATE_GREATHER_THAN_NOW);

            RuleFor(x => x.Priority)
                .NotEmpty().WithMessage(Exceptions.Resources.ErrorMessages.PRIORITY_NOT_EMPTY)
                .Must(ValidationHelper.BeAValidPriority).WithMessage(Exceptions.Resources.ErrorMessages.PRIORITY_RANK);
        }
    }
}
