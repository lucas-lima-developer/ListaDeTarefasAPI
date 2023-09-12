using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
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
        }
    }
}
