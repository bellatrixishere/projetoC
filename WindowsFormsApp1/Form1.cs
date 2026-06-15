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


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Lista de itens do orçamento atual (persistente durante a edição do orçamento)
        private List<ItemOrcamento> itensOrcamento = new List<ItemOrcamento>();

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Nome = txtNome.Text;
            cliente.Contato = txtContato.Text;

            Dados.Clientes.Add(cliente);

            lstClientes.Items.Add(cliente);

            // Atualiza o DataSource do ComboBox para refletir a alteração
            cboCliente.DataSource = null;
            cboCliente.DataSource = Dados.Clientes;
            if (cboCliente.Items.Count > 0)
                cboCliente.SelectedIndex = 0;

            txtNome.Clear();
            txtContato.Clear();
        }

        private void btnCadastrarServico_Click(object sender, EventArgs e)
        {
            Servico servico = new Servico();

            servico.Nome = txtNomeServico.Text;
            decimal preco;
            if (!decimal.TryParse(txtPreco.Text, out preco))
            {
                MessageBox.Show("Preço inválido. Use número, ex: 120.50");
                return;
            }
            servico.Preco = preco;

            Dados.Servicos.Add(servico);

            // lstServicos é redundante quando usamos DataSource; atualiza a lista diretamente
            // Mantemos para compatibilidade visual
            lstServicos.Items.Add(servico);
            if (cboServico.Items.Count > 0)
                cboServico.SelectedIndex = 0;

            txtNomeServico.Clear();
            txtPreco.Clear();

        }


        private void Form1_Load(object sender, EventArgs e)
        { 
        // Vincula diretamente às listas em Dados para refletir alterações posteriores
            cboCliente.DataSource = Dados.Clientes;
            cboServico.DataSource = Dados.Servicos;

            cboMotivos.Items.Add("Preço muito alto");
            cboMotivos.Items.Add("Cliente desistiu");
            cboMotivos.Items.Add("Prazo incompatível");
            cboMotivos.Items.Add("Concorrente escolhido");

            if (cboMotivos.Items.Count > 0)
                cboMotivos.SelectedIndex = 0;
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            var servico = cboServico.SelectedItem as Servico;
            if (servico == null)
            {
                MessageBox.Show("Selecione um serviço antes de adicionar.");
                return;
            }

            ItemOrcamento item = new ItemOrcamento();
            item.Servico = servico;
            item.Quantidade = (int)numQuantidade.Value;

            // Adiciona o item à lista do orçamento atual
            itensOrcamento.Add(item);

            lstItens.Items.Add(item.Servico.Nome + " x " + item.Quantidade);
        }

        private void btnSalvarOrcamento_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente antes de salvar o orçamento.");
                return;
            }

            if (itensOrcamento.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um item ao orçamento.");
                return;
            }

            Orcamento orcamento = new Orcamento();
            orcamento.Cliente = (Cliente)cboCliente.SelectedItem;
            orcamento.Itens = new List<ItemOrcamento>(itensOrcamento);

            Dados.Orcamentos.Add(orcamento);

            MessageBox.Show("Total: " + orcamento.Total().ToString("C"));

            // Limpa estado da edição atual
            itensOrcamento.Clear();
            lstItens.Items.Clear();
            // Atualiza lista de orçamentos exibida
            lstOrcamentos.DataSource = null;
            lstOrcamentos.DataSource = Dados.Orcamentos;
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            var orc = lstOrcamentos.SelectedItem as Orcamento;
            if (orc == null)
            {
                MessageBox.Show("Selecione um orçamento para aprovar.");
                return;
            }

            orc.Status = "Aprovado";
            orc.NumeroPedido = Dados.ProximoPedido++;

            // Forçar atualização do DataSource
            lstOrcamentos.DataSource = null;
            lstOrcamentos.DataSource = Dados.Orcamentos;
        }

        private void btnReprovar_Click(object sender, EventArgs e)
        {
            var orc = lstOrcamentos.SelectedItem as Orcamento;

            if (orc == null)
                return;

            orc.Status = "Rejeitado";

            orc.MotivoRejeicao = cboMotivos.Text;

            lstOrcamentos.DataSource = null;
            lstOrcamentos.DataSource = Dados.Orcamentos;
        }

        private void txtNomeServico_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstOrcamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
