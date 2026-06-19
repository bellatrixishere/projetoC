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
                    // Preenche parâmetros da query com valores do objeto cliente
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Contato", cliente.Contato);

                    // Executa INSERT no banco
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

        public void Atualizar(Cliente cliente)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
            UPDATE Clientes
            SET Nome = @Nome,
                Contato = @Contato
            WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    // Define parâmetros e executa UPDATE para salvar alterações
                    cmd.Parameters.AddWithValue("@Id", cliente.Id);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Contato", cliente.Contato);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = "DELETE FROM Clientes WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    // Executa DELETE para remover cliente pelo Id
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}