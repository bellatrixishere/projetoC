using System;
using System.Data.SQLite;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1.Repositories
{
    public class OrcamentoRepository
    {
        public void Inserir(Orcamento orcamento)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
                    INSERT INTO Orcamentos
                    (ClienteId, Status, NumeroPedido, MotivoRejeicao)
                    VALUES
                    (@ClienteId, @Status, @NumeroPedido, @MotivoRejeicao);

                    SELECT last_insert_rowid();";

                long orcamentoId;

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue(
                        "@ClienteId",
                        orcamento.Cliente.Id);

                    cmd.Parameters.AddWithValue(
                        "@Status",
                        orcamento.Status);

                    cmd.Parameters.AddWithValue(
                        "@NumeroPedido",
                        (object)orcamento.NumeroPedido ?? DBNull.Value);

                    cmd.Parameters.AddWithValue(
                        "@MotivoRejeicao",
                        (object)orcamento.MotivoRejeicao ?? DBNull.Value);

                    orcamentoId =
                        (long)cmd.ExecuteScalar();
                }



                foreach (var item in orcamento.Itens)
                {
                    string sqlItem = @"
                        INSERT INTO ItensOrcamento
                        (OrcamentoId, ServicoId, Quantidade)
                        VALUES
                        (@OrcamentoId, @ServicoId, @Quantidade)";

                    using (var cmd =
                        new SQLiteCommand(sqlItem, conexao))
                    {
                        cmd.Parameters.AddWithValue(
                            "@OrcamentoId",
                            orcamentoId);

                        cmd.Parameters.AddWithValue(
                            "@ServicoId",
                            item.Servico.Id);

                        cmd.Parameters.AddWithValue(
                            "@Quantidade",
                            item.Quantidade);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
        }

        public List<Orcamento> Listar()
        {
            List<Orcamento> orcamentos =
                new List<Orcamento>();

            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
        SELECT
            o.Id,
            o.Status,
            o.NumeroPedido,
            o.MotivoRejeicao,
            c.Id AS ClienteId,
            c.Nome,
            c.Contato
        FROM Orcamentos o
        INNER JOIN Clientes c
            ON c.Id = o.ClienteId";

                using (var cmd = new SQLiteCommand(sql, conexao))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Orcamento orcamento =
                            new Orcamento();

                        orcamento.Id =
                            Convert.ToInt32(reader["Id"]);

                        orcamento.Status =
                            reader["Status"].ToString();

                        if (reader["NumeroPedido"] != DBNull.Value)
                        {
                            orcamento.NumeroPedido =
                                Convert.ToInt32(
                                    reader["NumeroPedido"]);
                        }

                        orcamento.MotivoRejeicao =
                            reader["MotivoRejeicao"].ToString();

                        orcamento.Cliente =
                            new Cliente
                            {
                                Id = Convert.ToInt32(
                                    reader["ClienteId"]),

                                Nome =
                                    reader["Nome"].ToString(),

                                Contato =
                                    reader["Contato"].ToString()
                            };

                        orcamento.Itens =
                            CarregarItens(
                                orcamento.Id,
                                conexao);

                        orcamentos.Add(
                            orcamento);
                    }
                }
            }

            return orcamentos;
        }

        private List<ItemOrcamento> CarregarItens(
    int orcamentoId,
    SQLiteConnection conexao)
        {
            List<ItemOrcamento> itens =
                new List<ItemOrcamento>();

            string sql = @"
    SELECT
        io.Id,
        io.Quantidade,
        s.Id AS ServicoId,
        s.Nome,
        s.Preco
    FROM ItensOrcamento io
    INNER JOIN Servicos s
        ON s.Id = io.ServicoId
    WHERE io.OrcamentoId = @OrcamentoId";

            using (var cmd =
                new SQLiteCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue(
                    "@OrcamentoId",
                    orcamentoId);

                using (var reader =
                    cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemOrcamento item =
                            new ItemOrcamento();

                        item.Id =
                            Convert.ToInt32(
                                reader["Id"]);

                        item.Quantidade =
                            Convert.ToInt32(
                                reader["Quantidade"]);

                        item.Servico =
                            new Servico
                            {
                                Id = Convert.ToInt32(
                                    reader["ServicoId"]),

                                Nome =
                                    reader["Nome"].ToString(),

                                Preco =
                                    Convert.ToDecimal(
                                        reader["Preco"])
                            };

                        itens.Add(item);
                    }
                }
            }

            return itens;
        }

        public void Atualizar(Orcamento orcamento)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
        UPDATE Orcamentos
        SET
            Status = @Status,
            NumeroPedido = @NumeroPedido,
            MotivoRejeicao = @MotivoRejeicao
        WHERE Id = @Id";

                using (var cmd =
                    new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue(
                        "@Id",
                        orcamento.Id);

                    cmd.Parameters.AddWithValue(
                        "@Status",
                        orcamento.Status);

                    cmd.Parameters.AddWithValue(
                        "@NumeroPedido",
                        (object)orcamento.NumeroPedido
                        ?? DBNull.Value);

                    cmd.Parameters.AddWithValue(
                        "@MotivoRejeicao",
                        (object)orcamento.MotivoRejeicao
                        ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                // Primeiro apaga os itens
                string sqlItens = "DELETE FROM ItensOrcamento WHERE OrcamentoId = @Id";

                using (var cmd = new SQLiteCommand(sqlItens, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }

                // Depois apaga o orçamento
                string sqlOrcamento = "DELETE FROM Orcamentos WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(sqlOrcamento, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}