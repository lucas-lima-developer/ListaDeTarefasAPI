using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Application.Mappings;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.UseCases.CreateTarefa;
using ListaDeTarefas.Application.UseCases.CreateUser;
using ListaDeTarefas.Application.UseCases.DeleteTarefa;
using ListaDeTarefas.Application.UseCases.GetAllTarefa;
using ListaDeTarefas.Application.UseCases.GetByIdTarefa;
using ListaDeTarefas.Application.UseCases.LoginUser;
using ListaDeTarefas.Application.UseCases.UpdateTarefa;
using ListaDeTarefas.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace ListaDeTarefas.Application
{
    public static class ServiceExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddMapper(services);
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
                .AddScoped<IUpdateTarefaUseCase, UpdateTarefaUseCase>()
                .AddScoped<ICreateUserUseCase, CreateUserUseCase>()
                .AddScoped<ILoginUserUseCase, LoginUserUseCase>();
        }

        private static void AddValidators(IServiceCollection services)
        {
            services
                .AddScoped<IValidator<CreateTarefaRequest>, CreateTarefaValidator>()
                .AddScoped<IValidator<UpdateTarefaRequest>, UpdateTarefaValidator>();
        }

        private static void AddMapper(IServiceCollection services)
        {
            services
                .AddAutoMapper(cfg =>
                {
                    cfg.AddProfiles(new List<Profile>
                    {
                        new CreateTarefaMapper(),
                        new UpdateTarefaMapper(),
                        new DeleteTarefaMapper(),
                        new GetByIdTarefaMapper(),
                        new GetAllTarefaMapper(),
                        new CreateUserMapper()
                    });
                });
        }
    }
}
