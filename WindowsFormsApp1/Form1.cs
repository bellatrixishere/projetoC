using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.Modelos;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<ItemOrcamento> itensOrcamento =
            new List<ItemOrcamento>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarListas();

            cboMotivos.Items.Clear();

            cboMotivos.Items.Add("Preço muito alto");
            cboMotivos.Items.Add("Cliente desistiu");
            cboMotivos.Items.Add("Prazo incompatível");
            cboMotivos.Items.Add("Concorrente escolhido");

            if (cboMotivos.Items.Count > 0)
                cboMotivos.SelectedIndex = 0;

            ClienteRepository repo = new ClienteRepository();

            Dados.Clientes.Clear();

            foreach (Cliente cliente in repo.Listar())
            {
                Dados.Clientes.Add(cliente);
            }

            AtualizarListas();
        }

        private void AtualizarListas()
        {
            lstClientes.DataSource = null;
            lstClientes.DataSource = Dados.Clientes;

            lstServicos.DataSource = null;
            lstServicos.DataSource = Dados.Servicos;

            lstOrcamentos.DataSource = null;
            lstOrcamentos.DataSource = Dados.Orcamentos;

            cboCliente.DataSource = null;
            cboCliente.DataSource = Dados.Clientes;

            cboServico.DataSource = null;
            cboServico.DataSource = Dados.Servicos;
        }

        //---------------------------------
        // CLIENTE
        //---------------------------------

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(txtNome.Text)
                ||
                string.IsNullOrWhiteSpace(txtContato.Text)
            )
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            Cliente cliente = new Cliente();

            cliente.Nome = txtNome.Text;
            cliente.Contato = txtContato.Text;

            ClienteRepository repo =
               new ClienteRepository();

            repo.Inserir(cliente);

            AtualizarListas();

            txtNome.Clear();
            txtContato.Clear();

            MessageBox.Show("Cliente cadastrado.");
        }

        private void EditarCliente_Click(
            object sender,
            EventArgs e)
        {
            Cliente cliente =
                lstClientes.SelectedItem as Cliente;

            if (cliente == null)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            cliente.Nome = txtNome.Text;
            cliente.Contato = txtContato.Text;

            AtualizarListas();

            txtNome.Clear();
            txtContato.Clear();

            MessageBox.Show("Cliente atualizado.");
        }

        private void Excluir_Click(
            object sender,
            EventArgs e)
        {
            Cliente cliente =
                lstClientes.SelectedItem as Cliente;

            if (cliente == null)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            Dados.Clientes.Remove(cliente);

            AtualizarListas();

            txtNome.Clear();
            txtContato.Clear();

            MessageBox.Show("Cliente removido.");
        }

        private void lstClientes_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            Cliente cliente =
                lstClientes.SelectedItem as Cliente;

            if (cliente == null)
                return;

            txtNome.Text =
                cliente.Nome;

            txtContato.Text =
                cliente.Contato;
        }

        //---------------------------------
        // SERVIÇO
        //---------------------------------

        private void btnCadastrarServico_Click(
            object sender,
            EventArgs e)
        {
            decimal preco;

            if (
                string.IsNullOrWhiteSpace(
                    txtNomeServico.Text)
                ||
                !decimal.TryParse(
                    txtPreco.Text,
                    out preco)
            )
            {
                MessageBox.Show(
                    "Preencha corretamente."
                );
                return;
            }

            Servico servico =
                new Servico();

            servico.Nome =
                txtNomeServico.Text;

            servico.Preco =
                preco;

            Dados.Servicos.Add(
                servico);

            AtualizarListas();

            txtNomeServico.Clear();
            txtPreco.Clear();

            MessageBox.Show(
                "Serviço cadastrado."
            );
        }

        private void button2_Click(
            object sender,
            EventArgs e)
        {
            Servico servico =
                lstServicos.SelectedItem
                as Servico;

            if (servico == null)
            {
                MessageBox.Show(
                    "Selecione um serviço."
                );
                return;
            }

            decimal preco;

            if (
                !decimal.TryParse(
                    txtPreco.Text,
                    out preco)
            )
            {
                MessageBox.Show(
                    "Preço inválido."
                );
                return;
            }

            servico.Nome =
                txtNomeServico.Text;

            servico.Preco =
                preco;

            AtualizarListas();

            MessageBox.Show(
                "Serviço atualizado."
            );
        }

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            Servico servico =
                lstServicos.SelectedItem
                as Servico;

            if (servico == null)
                return;

            Dados.Servicos.Remove(
                servico);

            AtualizarListas();

            txtNomeServico.Clear();
            txtPreco.Clear();

            MessageBox.Show(
                "Serviço removido."
            );
        }

        private void listBox1_SelectedIndexChanged_1(
            object sender,
            EventArgs e)
        {
            Servico servico =
                lstServicos.SelectedItem
                as Servico;

            if (servico == null)
                return;

            txtNomeServico.Text =
                servico.Nome;

            txtPreco.Text =
                servico.Preco.ToString();
        }

        //---------------------------------
        // ORÇAMENTO
        //---------------------------------

        private void btnAdicionarItem_Click(
            object sender,
            EventArgs e)
        {
            Servico servico =
                cboServico.SelectedItem
                as Servico;

            if (servico == null)
                return;

            ItemOrcamento item =
                new ItemOrcamento();

            item.Servico =
                servico;

            item.Quantidade =
                (int)numQuantidade.Value;

            itensOrcamento.Add(item);

            lstItens.Items.Add(
                $"{item.Servico.Nome} | " +
                $"Qtd:{item.Quantidade} | " +
                $"{item.SubTotal():C}"
            );
        }

        private void btnSalvarOrcamento_Click(
            object sender,
            EventArgs e)
        {
            if (
                cboCliente.SelectedItem == null
                ||
                itensOrcamento.Count == 0
            )
            {
                MessageBox.Show(
                    "Dados incompletos."
                );

                return;
            }

            Orcamento o =
                new Orcamento();

            o.Cliente =
                (Cliente)cboCliente.SelectedItem;

            o.Itens =
                new List<ItemOrcamento>(
                    itensOrcamento);

            Dados.Orcamentos.Add(o);

            MessageBox.Show(
                $"Total: {o.Total():C}"
            );

            itensOrcamento.Clear();

            lstItens.Items.Clear();

            AtualizarListas();
        }

        private void btnAprovar_Click(
            object sender,
            EventArgs e)
        {
            Orcamento o =
                lstOrcamentos.SelectedItem
                as Orcamento;

            if (o == null)
                return;

            o.Status =
                "Aprovado";

            o.NumeroPedido =
                Dados.ProximoPedido++;

            AtualizarListas();
        }

        private void btnReprovar_Click(
            object sender,
            EventArgs e)
        {
            Orcamento o =
                lstOrcamentos.SelectedItem
                as Orcamento;

            if (o == null)
                return;

            o.Status =
                "Rejeitado";

            o.MotivoRejeicao =
                cboMotivos.Text;

            AtualizarListas();
        }

        //---------------------------------
        // EVENTOS VAZIOS
        //---------------------------------

        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtNomeServico_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lstOrcamentos_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }
    }
}