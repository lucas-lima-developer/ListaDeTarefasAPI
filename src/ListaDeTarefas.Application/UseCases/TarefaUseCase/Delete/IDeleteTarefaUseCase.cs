using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete
{
    public interface IDeleteTarefaUseCase
    {
        Task Execute(long tarefaId);
    }
}
