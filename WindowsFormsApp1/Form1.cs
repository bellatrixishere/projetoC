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

            txtNome.Clear();
            txtContato.Clear();
        }

        private void btnCadastrarServico_Click(object sender, EventArgs e)
        {
            Servico servico = new Servico();

            servico.Nome = txtNomeServico.Text;
            servico.Preco = txtPreco.Text != "" ? decimal.Parse(txtPreco.Text) : 0;

            Dados.Servicos.Add(servico);

            lstServicos.Items.Add(servico);
            // Atualiza o DataSource do ComboBox para refletir a alteração
            cboServico.DataSource = null;
            cboServico.DataSource = Dados.Servicos.ToList();
            if (cboServico.Items.Count > 0)
                cboServico.SelectedIndex = 0;

            txtNomeServico.Clear();
            txtPreco.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            cboCliente.DataSource = Dados.Clientes.ToList();
            cboServico.DataSource = Dados.Servicos.ToList();
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

            List<ItemOrcamento> itens = new List<ItemOrcamento>();
            itens.Add(item);

            lstItens.Items.Add(item.Servico.Nome + " x " + item.Quantidade);
        }

        private void btnSalvarOrcamento_Click(object sender, EventArgs e)
        {
            List<ItemOrcamento> itens = new List<ItemOrcamento>();

            Orcamento orcamento = new Orcamento();
            orcamento.Cliente = (Cliente)cboCliente.SelectedItem;
            orcamento.Itens = itens;

            Dados.Orcamentos.Add(orcamento);

            MessageBox.Show("Total: R$ " + orcamento.Total());
        }

        private void txtNomeServico_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
