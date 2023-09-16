using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetById
{
    public class GetByIdTarefaUseCase : IGetByIdTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public GetByIdTarefaUseCase(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Tarefa> Execute(long id)
        {
            var tarefa = await _tarefaRepository.Get(id);

            return tarefa;
        }
    }
}
