using AutoMapper;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.Mappings
{
    public sealed class GetByIdTarefaMapper : Profile
    {
        public GetByIdTarefaMapper()
        {
            CreateMap<Tarefa, GetByIdTarefaResponse>();
        }
    }
}
