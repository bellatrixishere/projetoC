using System;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Modelos;
using WindowsFormsApp1.Repositories;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Banco.Inicializar();

            // Cria admin padrão se não existir nenhum usuário
            UsuarioService service = new UsuarioService();

            if (!service.ExisteAlgumUsuario())
            {
                UsuarioRepository repo = new UsuarioRepository();

                // Busca o papel Admin (Id=1)
                Papel papelAdmin = new Papel { Id = 1, Nome = "Admin" };

                Usuario admin = new Usuario
                {
                    Nome = "Administrador",
                    Login = "admin",
                    SenhaHash = "1234",
                    Papel = papelAdmin
                };

                repo.Inserir(admin);

                MessageBox.Show(
                    "Primeiro acesso detectado.\n\n" +
                    "Usuário: admin\n" +
                    "Senha: 1234\n\n" +
                    "Troque a senha após entrar.",
                    "Bem-vindo"
                );
            }

            // Abre o login
            FormLogin login = new FormLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1(login.UsuarioLogado));
            }
        }
    }
}