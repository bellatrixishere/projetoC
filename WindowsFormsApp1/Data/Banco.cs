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

                string sqlServicos = @"
                CREATE TABLE IF NOT EXISTS Servicos
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Preco REAL NOT NULL
                )";

                string sqlOrcamentos = @"
                CREATE TABLE IF NOT EXISTS Orcamentos
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClienteId INTEGER NOT NULL,
                    Status TEXT NOT NULL,
                    NumeroPedido INTEGER,
                    MotivoRejeicao TEXT
                )";

                string sqlItens = @"
                CREATE TABLE IF NOT EXISTS ItensOrcamento
                (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                OrcamentoId INTEGER NOT NULL,
                ServicoId INTEGER NOT NULL,
                Quantidade INTEGER NOT NULL
                )";

                new SQLiteCommand(sqlOrcamentos, conexao)
                    .ExecuteNonQuery();

                new SQLiteCommand(sqlItens, conexao)
                    .ExecuteNonQuery();

                new SQLiteCommand(sqlServicos, conexao)
                .ExecuteNonQuery();

                SQLiteCommand cmd =
                    new SQLiteCommand(sql, conexao);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
