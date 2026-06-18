using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace WindowsFormsApp1.Data
{
    public class Banco
    {
        public static void Inicializar()
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS Clientes
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Contato TEXT NOT NULL
                );";

                SQLiteCommand cmd =
                    new SQLiteCommand(sql, conexao);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
