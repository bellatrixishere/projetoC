using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace WindowsFormsApp1.Data
{
    public class Conexao
    {
        private static string stringConexao =
            "Data Source=banco.db;Version=3;";

        public static SQLiteConnection ObterConexao()
        {
            return new SQLiteConnection(stringConexao);
        }
    }
}