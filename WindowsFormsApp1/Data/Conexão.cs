using System;
using System.IO;
using System.Data.SQLite;

namespace WindowsFormsApp1.Data
{
    public class Conexao
    {
        private static string ObterCaminhoBanco()
        {
            string pasta = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "OrcamentosPlatinum"
            );

            // Se a pasta não existir, cria. Assim garantimos que podemos criar o arquivo do DB.
            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            return Path.Combine(pasta, "banco.db");
        }

        public static SQLiteConnection ObterConexao()
        {
            string caminho = ObterCaminhoBanco();
            string stringConexao = $"Data Source={caminho};Version=3;";
            // Retorna o objeto de conexão. Note: a conexão ainda não está aberta.
            return new SQLiteConnection(stringConexao);
        }
    }
}