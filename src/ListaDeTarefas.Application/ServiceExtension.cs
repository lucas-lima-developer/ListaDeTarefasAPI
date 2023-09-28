using FluentValidation;
using ListaDeTarefas.Application.Shared.Behavior;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Add;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Delete;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.GetById;
using ListaDeTarefas.Application.UseCases.TarefaUseCase.Update;
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
            AddValidators(services);
        }

        private static void AddUseCases(IServiceCollection service)
        {
            service.AddScoped<IAddTarefaUseCase, AddTarefaUseCase>();
            service.AddScoped<IDeleteTarefaUseCase, DeleteTarefaUseCase>();
            service.AddScoped<IGetByIdTarefaUseCase, GetByIdTarefaUseCase>();
            service.AddScoped<IUpdateTearefaUseCase, UpdateTarefaUseCase>();
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<AddTarefaRequest>, AddTarefaRequestValidator>();
            services.AddTransient<IValidator<UpdateTarefaRequest>, UpdateTarefaRequestValidator>();
        }
    }
}
