using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ListaDeTarefas.Domain.Extensions;
using ListaDeTarefas.Infrastructure.Repositorios;

namespace ListaDeTarefas.Infrastructure
{
    public static class Bootstraper
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configurationManager)
        {
            AddContexto(services, configurationManager);
        }

        private static void AddContexto(IServiceCollection services, IConfiguration configurationManager)
        {
            var versaoServidor = new MySqlServerVersion("8.0.34");

            var conexaoString = configurationManager.GetConexaoCompleta();

            services.AddDbContext<ListaDeTarefasContext>(options =>
            {
                options.UseMySql(conexaoString, versaoServidor);
            });
        }
    }
}
