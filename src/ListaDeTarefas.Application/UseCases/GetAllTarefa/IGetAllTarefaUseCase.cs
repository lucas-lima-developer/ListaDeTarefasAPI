using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaDeTarefas.Application.Responses;

namespace ListaDeTarefas.Application.UseCases.GetAllTarefa
{
    public interface IGetAllTarefaUseCase
    {
        Task<List<GetAllTarefaResponse>> Execute(CancellationToken cancellationToken);
    }
}
