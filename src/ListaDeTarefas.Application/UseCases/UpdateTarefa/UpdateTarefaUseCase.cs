using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.UpdateTarefa
{
    public class UpdateTarefaUseCase : IUpdateTarefaUseCase
    {

        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWorK;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTarefaRequest> _validator;

        public UpdateTarefaUseCase(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWorK, IMapper mapper, IValidator<UpdateTarefaRequest> validator)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWorK = unitOfWorK;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateTarefaResponse> Execute(UpdateTarefaRequest request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
                throw new ValidationErrorException(result);

            var tarefa = await _tarefaRepository.GetById(request.Id, cancellationToken);

            if (tarefa == null)
                throw new TarefaNotFoundException(request.Id);

            _mapper.Map(request, tarefa);

            tarefa.CompletionDate = request.IsCompleted ? DateTime.Now : null;

            _tarefaRepository.Update(tarefa);

            await _unitOfWorK.Commit(cancellationToken);

            return _mapper.Map<UpdateTarefaResponse>(tarefa);
        }
    }
}
