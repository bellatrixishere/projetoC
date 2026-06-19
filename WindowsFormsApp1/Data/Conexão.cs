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

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            return Path.Combine(pasta, "banco.db");
        }

        public static SQLiteConnection ObterConexao()
        {
            string caminho = ObterCaminhoBanco();
            string stringConexao = $"Data Source={caminho};Version=3;";
            return new SQLiteConnection(stringConexao);
        }
    }
}