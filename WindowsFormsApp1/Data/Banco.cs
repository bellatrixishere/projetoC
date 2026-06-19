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

                new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS Clientes
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Contato TEXT NOT NULL
                    );", conexao).ExecuteNonQuery();

                new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS Servicos
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Preco REAL NOT NULL
                    );", conexao).ExecuteNonQuery();

                new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS Orcamentos
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClienteId INTEGER NOT NULL,
                        Status TEXT NOT NULL,
                        NumeroPedido INTEGER,
                        MotivoRejeicao TEXT
                    );", conexao).ExecuteNonQuery();

                new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS ItensOrcamento
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        OrcamentoId INTEGER NOT NULL,
                        ServicoId INTEGER NOT NULL,
                        Quantidade INTEGER NOT NULL
                    );", conexao).ExecuteNonQuery();

                // NOVAS TABELAS
                new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS Papeis
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL UNIQUE
                    );", conexao).ExecuteNonQuery();

                new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS Usuarios
                    (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Login TEXT NOT NULL UNIQUE,
                        SenhaHash TEXT NOT NULL,
                        PapelId INTEGER NOT NULL,
                        FOREIGN KEY (PapelId) REFERENCES Papeis(Id)
                    );", conexao).ExecuteNonQuery();

                // Insere os 3 papéis fixos se não existirem
                new SQLiteCommand(@"
                    INSERT OR IGNORE INTO Papeis (Nome)
                    VALUES ('Admin'), ('Operador'), ('Visualizador');
                ", conexao).ExecuteNonQuery();
            }
        }
    }
}
