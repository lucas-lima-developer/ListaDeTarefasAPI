using Dapper;
using MySqlConnector;

namespace ListaDeTarefas.Infrastructure
{
    public static class Database
    {
        public static void CriarDatabase(string conexaoBancoDeDados, string nomeDatabase)
        {
            using var minhaConexao = new MySqlConnection(conexaoBancoDeDados);

            var parametros = new DynamicParameters();
            parametros.Add("nome", nomeDatabase);

            var registros = minhaConexao.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @nome", parametros);

            if (!registros.Any()) 
            {
                minhaConexao.Query($"CREATE DATABASE {nomeDatabase}");
            }
        }
    }
}
