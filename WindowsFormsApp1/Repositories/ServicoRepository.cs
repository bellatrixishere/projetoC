using System;
using System.Collections.Generic;
using System.Data.SQLite;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Modelos;

namespace WindowsFormsApp1.Repositories
{
    public class ServicoRepository
    {
        public void Inserir(Servico servico)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
                    INSERT INTO Servicos
                    (Nome, Preco)
                    VALUES
                    (@Nome, @Preco)";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    // Preenche parâmetros e executa INSERT para criar novo serviço
                    cmd.Parameters.AddWithValue("@Nome", servico.Nome);
                    cmd.Parameters.AddWithValue("@Preco", servico.Preco);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Servico> Listar()
        {
            List<Servico> servicos = new List<Servico>();

            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = "SELECT * FROM Servicos";

                using (var cmd = new SQLiteCommand(sql, conexao))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Servico servico = new Servico();

                        servico.Id = Convert.ToInt32(reader["Id"]);
                        servico.Nome = reader["Nome"].ToString();
                        servico.Preco = Convert.ToDecimal(reader["Preco"]);

                        servicos.Add(servico);
                    }
                }
            }

            return servicos;
        }

        public void Atualizar(Servico servico)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
                    UPDATE Servicos
                    SET Nome = @Nome,
                        Preco = @Preco
                    WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    // Atualiza serviço no banco com os novos valores
                    cmd.Parameters.AddWithValue("@Id", servico.Id);
                    cmd.Parameters.AddWithValue("@Nome", servico.Nome);
                    cmd.Parameters.AddWithValue("@Preco", servico.Preco);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = "DELETE FROM Servicos WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    // Deleta serviço pelo id
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}