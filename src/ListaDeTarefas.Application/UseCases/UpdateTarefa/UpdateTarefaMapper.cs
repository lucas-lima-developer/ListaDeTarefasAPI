using AutoMapper;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.UpdateTarefa
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
