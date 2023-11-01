using AutoMapper;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.Mappings
{
    public sealed class UpdateTarefaMapper : Profile
    {
        public UpdateTarefaMapper()
        {
            CreateMap<UpdateTarefaRequest, Tarefa>();
            CreateMap<Tarefa, UpdateTarefaResponse>();
        }
    }
}
