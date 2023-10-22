using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.UseCases.UpdateTarefa
{
    public class UpdateTarefaRequest
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LimitDate { get; set; }
        public string? Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
