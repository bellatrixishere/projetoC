using System.Collections.Generic;
using System.Data.SQLite;
using BCrypt.Net;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Modelos;

namespace WindowsFormsApp1.Repositories
{
    public class UsuarioRepository
    {
        public void Inserir(Usuario usuario)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
                    INSERT INTO Usuarios
                    (Nome, Login, SenhaHash, PapelId)
                    VALUES
                    (@Nome, @Login, @SenhaHash, @PapelId)";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    // Prepara dados do usuário. A senha é transformada em hash antes de salvar.
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Login", usuario.Login);
                    cmd.Parameters.AddWithValue("@SenhaHash",
                        BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash));
                    cmd.Parameters.AddWithValue("@PapelId", usuario.Papel.Id);

                    // Executa inserção
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Usuario Validar(string login, string senha)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
                    SELECT
                        u.Id,
                        u.Nome,
                        u.Login,
                        u.SenhaHash,
                        p.Id AS PapelId,
                        p.Nome AS PapelNome
                    FROM Usuarios u
                    INNER JOIN Papeis p ON p.Id = u.PapelId
                    WHERE u.Login = @Login";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@Login", login);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Obtém hash do banco e compara com a senha fornecida
                            string hash = reader["SenhaHash"].ToString();

                            if (BCrypt.Net.BCrypt.Verify(senha, hash))
                            {
                                // Senha válida: monta objeto Usuario com Papel
                                return new Usuario
                                {
                                    Id = System.Convert.ToInt32(reader["Id"]),
                                    Nome = reader["Nome"].ToString(),
                                    Login = reader["Login"].ToString(),
                                    SenhaHash = hash,
                                    Papel = new Papel
                                    {
                                        Id = System.Convert.ToInt32(reader["PapelId"]),
                                        Nome = reader["PapelNome"].ToString()
                                    }
                                };
                            }
                        }
                    }
                }
            }

            return null;
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = @"
                    SELECT
                        u.Id,
                        u.Nome,
                        u.Login,
                        u.SenhaHash,
                        p.Id AS PapelId,
                        p.Nome AS PapelNome
                    FROM Usuarios u
                    INNER JOIN Papeis p ON p.Id = u.PapelId";

                using (var cmd = new SQLiteCommand(sql, conexao))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = System.Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Login = reader["Login"].ToString(),
                            SenhaHash = reader["SenhaHash"].ToString(),
                            Papel = new Papel
                            {
                                Id = System.Convert.ToInt32(reader["PapelId"]),
                                Nome = reader["PapelNome"].ToString()
                            }
                        });
                    }
                }
            }

            return usuarios;
        }

        public void Excluir(int id)
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = "DELETE FROM Usuarios WHERE Id = @Id";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Papel> ListarPapeis()
        {
            List<Papel> papeis = new List<Papel>();

            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = "SELECT Id, Nome FROM Papeis";

                using (var cmd = new SQLiteCommand(sql, conexao))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        papeis.Add(new Papel
                        {
                            Id = System.Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString()
                        });
                    }
                }
            }

            return papeis;
        }

        public bool ExisteAlgumUsuario()
        {
            using (var conexao = Conexao.ObterConexao())
            {
                conexao.Open();

                string sql = "SELECT COUNT(*) FROM Usuarios";

                using (var cmd = new SQLiteCommand(sql, conexao))
                {
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}