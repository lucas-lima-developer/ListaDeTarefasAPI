using FluentValidation;
using ListaDeTarefas.Application.Shared.Behavior;
using ListaDeTarefas.Application.UseCases.CreateTarefa;
using ListaDeTarefas.Application.UseCases.GetAllTarefa;
using ListaDeTarefas.Application.UseCases.GetByIdTarefa;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ListaDeTarefas.Application
{
    public static class ServiceExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services
                .AddScoped<IGetAllTarefaUseCase, GetAllTarefaUseCase>()
                .AddScoped<IGetByIdTarefaUseCase, GetByIdTarefaUseCase>()
                .AddScoped<ICreateTarefaUseCase, CreateTarefaUseCase>();
        }
    }
}
