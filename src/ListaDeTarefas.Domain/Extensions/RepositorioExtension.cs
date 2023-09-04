using Microsoft.Extensions.Configuration;

namespace ListaDeTarefas.Domain.Extensions
{
    public static class RepositorioExtension
    {
        public static string GetNomeDatabase(this IConfiguration configurationManager)
        {
            var nomeDatabase = configurationManager.GetConnectionString("NomeDatabase");

            return $"{nomeDatabase}";
        }

        public static string GetConexao(this IConfiguration configurationManager)
        {
            var conexao = configurationManager.GetConnectionString("Conexao");

            return $"{conexao}";
        }
    }
}
