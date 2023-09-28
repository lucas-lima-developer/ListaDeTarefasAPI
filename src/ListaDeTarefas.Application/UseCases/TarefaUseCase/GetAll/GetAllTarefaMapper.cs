using AutoMapper;
using ListaDeTarefas.Domain.Entities;

namespace ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll
{
    public sealed class GetAllTarefaMapper : Profile
    {
        public GetAllTarefaMapper() 
        {
            CreateMap<Tarefa, GetAllTarefaResponse>();
        }
    }
}
