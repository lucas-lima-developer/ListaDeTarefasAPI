using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.CreateTarefa
{
    public class CreateTarefaUseCase : ICreateTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTarefaRequest> _validator;

        public CreateTarefaUseCase(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateTarefaRequest> validator)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateTarefaResponse> Execute(CreateTarefaRequest request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                throw new ValidationErrorException(result);
            }

            var tarefa = _mapper.Map<Tarefa>(request);

            _tarefaRepository.Create(tarefa);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateTarefaResponse>(tarefa);
        }
    }
}
