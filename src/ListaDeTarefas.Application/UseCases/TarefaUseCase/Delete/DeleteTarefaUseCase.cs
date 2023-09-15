using ListaDeTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete
{
    public class DeleteTarefaUseCase : IDeleteTarefaUseCase
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTarefaUseCase(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long tarefaId)
        {
            var tarefa = await _tarefaRepository.Get(tarefaId);
            if (tarefa != null) 
            {
                _tarefaRepository.Delete(tarefa);
                await _unitOfWork.Commit();
            }
        }
    }
}
