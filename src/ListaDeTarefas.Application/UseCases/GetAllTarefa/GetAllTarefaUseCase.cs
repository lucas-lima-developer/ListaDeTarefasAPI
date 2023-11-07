using AutoMapper;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.GetAllTarefa
{
    public class GetAllTarefaUseCase : IGetAllTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllTarefaUseCase(ITarefaRepository tarefaRepository, IUserRepository userRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllTarefaResponse>> Execute(string emailUser, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(emailUser, cancellationToken);

            var tarefas = await _tarefaRepository.GetAll(user!, cancellationToken);

            if (tarefas?.Count == 0) throw new TarefaNotFoundException("Nenhuma tarefa encontrada.");

            return _mapper.Map<List<GetAllTarefaResponse>>(tarefas);
        }
    }
}
