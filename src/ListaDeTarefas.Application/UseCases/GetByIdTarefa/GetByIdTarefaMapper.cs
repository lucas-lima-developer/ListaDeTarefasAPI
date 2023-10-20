using AutoMapper;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.GetByIdTarefa
{
    public sealed class GetByIdTarefaMapper : Profile
    {
        public GetByIdTarefaMapper()
        {
            CreateMap<Tarefa, GetByIdTarefaResponse>();
        }
    }
}
