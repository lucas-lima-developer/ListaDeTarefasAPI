using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Complete;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetById;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Update;
using Microsoft.Extensions.DependencyInjection;

namespace ListaDeTarefas.Application
{
    public static class ServiceExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection service)
        {
            service.AddScoped<IAddTarefaUseCase, AddTarefaUseCase>();
            service.AddScoped<IGetAllTarefaUseCase, GetAllTarefaUseCase>();
            service.AddScoped<IDeleteTarefaUseCase, DeleteTarefaUseCase>();
            service.AddScoped<IGetByIdTarefaUseCase, GetByIdTarefaUseCase>();
            service.AddScoped<IUpdateTearefaUseCase, UpdateTarefaUseCase>();
            service.AddScoped<ICompleteTarefaUseCase, CompleteTarefaUseCase>();
        }
    }
}
