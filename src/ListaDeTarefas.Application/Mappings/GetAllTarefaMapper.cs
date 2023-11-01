using AutoMapper;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.Mappings
{
    public sealed class GetAllTarefaMapper : Profile
    {
        public GetAllTarefaMapper()
        {
            CreateMap<Tarefa, GetAllTarefaResponse>();
        }
    }
}
