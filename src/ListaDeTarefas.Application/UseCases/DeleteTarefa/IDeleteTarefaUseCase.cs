using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.UseCases.DeleteTarefa
{
    public interface IDeleteTarefaUseCase
    {
        public Task<DeleteTarefaResponse> Execute(int id, CancellationToken cancellationToken);
    }
}
