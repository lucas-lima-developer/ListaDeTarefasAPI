using AutoMapper;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.GetByIdTarefa
{
    public class GetByIdTarefaUseCase : IGetByIdTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetByIdTarefaUseCase(ITarefaRepository tarefaRepository, IUserRepository userRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTarefaResponse> Execute(int id, string userEmail, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(userEmail, cancellationToken);

            if (user is null) throw new Exception("Usuário não encontrado");

            var tarefa = await _tarefaRepository.GetById(user, id, cancellationToken);

            if (tarefa == null) throw new TarefaNotFoundException(id);

            return _mapper.Map<GetByIdTarefaResponse>(tarefa);
        }
    }
}
