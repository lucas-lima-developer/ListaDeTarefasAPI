using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetAll;
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
        }
    }
}
