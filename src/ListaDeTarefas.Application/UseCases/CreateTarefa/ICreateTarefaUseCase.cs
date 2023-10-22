using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.UseCases.CreateTarefa
{
    public interface ICreateTarefaUseCase
    {
        Task<CreateTarefaResponse> Execute(CreateTarefaRequest request, CancellationToken cancellationToken);
    }
}
