using AutoMapper;
using ListaDeTarefas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.UseCases.DeleteTarefa
{
    public sealed class DeleteTarefaMapper : Profile
    {
        public DeleteTarefaMapper()
        {
            CreateMap<Tarefa, DeleteTarefaResponse>();
        }
    }
}
