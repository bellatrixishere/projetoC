using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Modelos;
using WindowsFormsApp1.Services;


namespace WindowsFormsApp1
{
    public partial class FormLogin : Form
    {
        public Usuario UsuarioLogado { get; private set; }

        private UsuarioService _service = new UsuarioService();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha usuário e senha.");
                return;
            }

            Usuario usuario = _service.Autenticar(login, senha);

            if (usuario != null)
            {
                UsuarioLogado = usuario;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
                txtSenha.Clear();
                txtLogin.Focus();
            }
        }

    }
}

