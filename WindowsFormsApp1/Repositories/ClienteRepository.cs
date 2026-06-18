using System;
using System.Collections.Generic;
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

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = "SELECT * FROM Clientes";

                using (var cmd = new SQLiteCommand(sql, conexao))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();

                        cliente.Id = Convert.ToInt32(reader["Id"]);
                        cliente.Nome = reader["Nome"].ToString();
                        cliente.Contato = reader["Contato"].ToString();

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }
    }
}