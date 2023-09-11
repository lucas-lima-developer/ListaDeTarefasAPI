using Microsoft.Extensions.Configuration;

namespace ListaDeTarefas.Domain.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetDatabaseName(this IConfiguration configurationManager)
        {
            var database = configurationManager.GetConnectionString("NomeDatabase");

            return $"{database}";
        }

        public static string GetConnectionString(this IConfiguration configurationManager)
        {
            var connectionString = configurationManager.GetConnectionString("Conexao");

            return $"{connectionString}";
        }

        public static string GetConnectionStrigCompleted(this IConfiguration configurationManager)
        {
            var connectionString = configurationManager.GetConnectionString();
            var database = configurationManager.GetDatabaseName();

            return $"{connectionString}Database={database}";
        }
    }
}
