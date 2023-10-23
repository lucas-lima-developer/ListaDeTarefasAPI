using FluentValidation;
using ListaDeTarefas.Application.UseCases.CreateTarefa;
using ListaDeTarefas.Application.UseCases.DeleteTarefa;
using ListaDeTarefas.Application.UseCases.GetAllTarefa;
using ListaDeTarefas.Application.UseCases.GetByIdTarefa;
using ListaDeTarefas.Application.UseCases.UpdateTarefa;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ListaDeTarefas.Application
{
    public static class ServiceExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            AddValidators(services);
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services
                .AddScoped<IGetAllTarefaUseCase, GetAllTarefaUseCase>()
                .AddScoped<IGetByIdTarefaUseCase, GetByIdTarefaUseCase>()
                .AddScoped<ICreateTarefaUseCase, CreateTarefaUseCase>()
                .AddScoped<IDeleteTarefaUseCase, DeleteTarefaUseCase>()
                .AddScoped<IUpdateTarefaUseCase, UpdateTarefaUseCase>();
        }

        private static void AddValidators(IServiceCollection services)
        {
            services
                .AddScoped<IValidator<CreateTarefaRequest>, CreateTarefaValidator>();
        }
    }
}
