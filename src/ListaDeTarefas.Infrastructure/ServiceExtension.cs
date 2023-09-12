using Dapper;
using ListaDeTarefas.Domain.Extensions;
using ListaDeTarefas.Domain.Interfaces;
using ListaDeTarefas.Infrastructure.Context;
using ListaDeTarefas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace ListaDeTarefas.Infrastructure
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddContext(services, configuration);

            AddRepositories(services);

            CreateDatabase(configuration);
        }

        private static void AddContext(IServiceCollection services, IConfiguration configuration)
        {
            var versaoServidor = new MySqlServerVersion("8.0.34");

            var conexaoString = configuration.GetConnectionStrigCompleted();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(conexaoString, versaoServidor);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITarefaRepository, TarefaRepository>();
        }

        private static void CreateDatabase(IConfiguration configuration)
        {
            var databaseConnectionString = configuration.GetConnectionString();
            var databaseName = configuration.GetDatabaseName();


            using var myConnection = new MySqlConnection(databaseConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("nome", databaseName);

            var records = myConnection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @nome", parameters);

            if (!records.Any())
            {
                myConnection.Query($"CREATE DATABASE {databaseName}");
            }
        }
    }
}
