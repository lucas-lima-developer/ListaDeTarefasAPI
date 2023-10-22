using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.UseCases.DeleteTarefa
{
    public sealed record DeleteTarefaResponse
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LimitDate { get; set; }
        public string? Priority { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
