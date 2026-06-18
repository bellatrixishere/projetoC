using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Modelos;

namespace WindowsFormsApp1.Repositories
{
    public class ClienteRepository
    {
        public void Inserir(Cliente cliente)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
                    INSERT INTO Clientes
                    (Nome, Contato)
                    VALUES
                    (@Nome, @Contato)";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Contato", cliente.Contato);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
