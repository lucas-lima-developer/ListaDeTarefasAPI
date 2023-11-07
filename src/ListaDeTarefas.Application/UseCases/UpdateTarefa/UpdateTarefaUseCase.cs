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
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWorK;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTarefaRequest> _validator;

        public UpdateTarefaUseCase(ITarefaRepository tarefaRepository, IUserRepository userRepository, IUnitOfWork unitOfWorK, IMapper mapper, IValidator<UpdateTarefaRequest> validator)
        {
            _tarefaRepository = tarefaRepository;
            _userRepository = userRepository;
            _unitOfWorK = unitOfWorK;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateTarefaResponse> Execute(UpdateTarefaRequest request, string email, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid) throw new ValidationErrorException(result);

            var user = await _userRepository.GetByEmail(email, cancellationToken);
            if (user is null) throw new UserNotFoundException();

            var tarefa = await _tarefaRepository.GetById(user, request.Id, cancellationToken);
            if (tarefa is null) throw new TarefaNotFoundException();

            _mapper.Map(request, tarefa);

            tarefa.CompletionDate = request.IsCompleted ? DateTime.Now : null;

            _tarefaRepository.Update(tarefa);
            await _unitOfWorK.Commit(cancellationToken);

            return _mapper.Map<UpdateTarefaResponse>(tarefa);
        }
    }
}
