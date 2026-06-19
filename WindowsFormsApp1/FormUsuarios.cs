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
    public partial class FormUsuarios : Form
    {
        private Usuario _usuarioLogado;
        private UsuarioService _service = new UsuarioService();

        public FormUsuarios(Usuario usuarioLogado)
        {
            InitializeComponent();
            _usuarioLogado = usuarioLogado;
        }

        private void CarregarPapeis()
        {
            cboPapel.DataSource = null;
            cboPapel.DataSource = _service.ListarPapeis();
        }

        private void CarregarUsuarios()
        {
            lstUsuarios.DataSource = null;
            lstUsuarios.DataSource = _service.Listar(_usuarioLogado);
        }

        //---------------------------------------------------------------------------------

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboPapel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
               string.IsNullOrWhiteSpace(txtLogin.Text) ||
               string.IsNullOrWhiteSpace(txtSenha.Text) ||
               cboPapel.SelectedItem == null)
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            Usuario novo = new Usuario
            {
                Nome = txtNome.Text.Trim(),
                Login = txtLogin.Text.Trim(),
                SenhaHash = txtSenha.Text,
                Papel = (Papel)cboPapel.SelectedItem
            };

            try
            {
                _service.CadastrarUsuario(novo, _usuarioLogado);
                MessageBox.Show("Usuário cadastrado com sucesso.");

                txtNome.Clear();
                txtLogin.Clear();
                txtSenha.Clear();

                CarregarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluirUsuario_Click(object sender, EventArgs e)
        {
            Usuario selecionado = lstUsuarios.SelectedItem as Usuario;

            if (selecionado == null)
            {
                MessageBox.Show("Selecione um usuário.");
                return;
            }

            if (selecionado.Login == "admin")
            {
                MessageBox.Show("O usuário admin não pode ser excluído.");
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                $"Excluir o usuário {selecionado.Nome}?",
                "Confirmar",
                MessageBoxButtons.YesNo
            );

            if (confirmacao != DialogResult.Yes)
                return;

            try
            {
                _service.Excluir(selecionado.Id, _usuarioLogado);
                MessageBox.Show("Usuário excluído.");
                CarregarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void lstUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormUsuarios_Load_1(object sender, EventArgs e)
        {
            CarregarPapeis();
            CarregarUsuarios();
        }
    }
}
