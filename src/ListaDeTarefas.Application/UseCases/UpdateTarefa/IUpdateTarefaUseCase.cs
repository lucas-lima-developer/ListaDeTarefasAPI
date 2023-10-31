using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;

namespace ListaDeTarefas.Application.UseCases.UpdateTarefa
{
    public interface IUpdateTarefaUseCase
    {
        public Task<UpdateTarefaResponse> Execute(UpdateTarefaRequest request, CancellationToken cancellationToken);
    }
}
