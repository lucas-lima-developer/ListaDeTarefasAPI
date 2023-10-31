using AutoMapper;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.Mappings
{
    public sealed class CreateTarefaMapper : Profile
    {
        public CreateTarefaMapper()
        {
            CreateMap<CreateTarefaRequest, Tarefa>();
            CreateMap<Tarefa, CreateTarefaResponse>();
        }
    }
}
