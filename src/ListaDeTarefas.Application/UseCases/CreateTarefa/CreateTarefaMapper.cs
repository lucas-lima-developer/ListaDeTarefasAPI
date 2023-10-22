using AutoMapper;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.CreateTarefa
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
