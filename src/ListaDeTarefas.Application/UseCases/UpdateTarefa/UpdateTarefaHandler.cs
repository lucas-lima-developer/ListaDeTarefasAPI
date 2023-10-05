using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Enum;
using ListaDeTarefas.Domain.Interfaces;
using MediatR;

namespace ListaDeTarefas.Application.UseCases.UpdateTarefa
{
    public sealed class UpdateTarefaHandler : IRequestHandler<UpdateTarefaRequest, UpdateTarefaResponse>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWorK;
        private readonly IMapper _mapper;

        public UpdateTarefaHandler(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWorK, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWorK = unitOfWorK;
            _mapper = mapper;
        }

        public async Task<UpdateTarefaResponse> Handle(UpdateTarefaRequest request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRepository.GetById(request.Id, cancellationToken);

            if (tarefa == null) throw new TarefaNotFoundException(request.Id);

            _mapper.Map(request, tarefa);

            _tarefaRepository.Update(tarefa);

            await _unitOfWorK.Commit(cancellationToken);

            return _mapper.Map<UpdateTarefaResponse>(tarefa);
        }
    }

    public sealed record UpdateTarefaRequest
        (long Id, string Title, string Description, DateTime LimitDate
        , Priority? Priority) : IRequest<UpdateTarefaResponse>;

    public class UpdateTarefaResponse
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

    public sealed class UpdateTarefaMapper : Profile
    {
        public UpdateTarefaMapper() 
        {
            CreateMap<UpdateTarefaRequest, Tarefa>();
            CreateMap<Tarefa, UpdateTarefaResponse>();
        }
    }

    public class UpdateTarefaValidator : AbstractValidator<UpdateTarefaRequest>
    {
        public UpdateTarefaValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThanOrEqualTo(1);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(150);
            RuleFor(x => x.LimitDate).NotEmpty();
            RuleFor(x => x.Priority).NotEmpty();
        }
    }
}
