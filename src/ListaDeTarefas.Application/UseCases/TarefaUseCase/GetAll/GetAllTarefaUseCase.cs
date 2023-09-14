using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll
{
    public class GetAllTarefaUseCase : IGetAllTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public GetAllTarefaUseCase(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<List<Tarefa>> Execute()
        {
            return await _tarefaRepository.GetAll();
        }
    }
}
