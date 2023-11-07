using AutoMapper;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.DeleteTarefa
{
    public class DeleteTarefaUseCase : IDeleteTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTarefaUseCase(ITarefaRepository tarefaRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteTarefaResponse> Execute(int id, string userEmail, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(userEmail, cancellationToken);
            if (user is null) throw new UserNotFoundException();

            var tarefa = await _tarefaRepository.GetById(user, id, cancellationToken);
            if (tarefa == null) throw new TarefaNotFoundException();

            _tarefaRepository.Delete(tarefa);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteTarefaResponse>(tarefa);
        }
    }
}
