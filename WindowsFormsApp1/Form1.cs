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



        private Usuario _usuarioLogado;

        public Form1(Usuario usuarioLogado)
        {
            InitializeComponent();
            _usuarioLogado = usuarioLogado;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ao carregar o formulário, traz os dados do banco para as listas em memória
            CarregarClientes();
            CarregarServicos();
            CarregarOrcamentos();

            // Atualiza os controles (ListBox / ComboBox) com os dados carregados
            AtualizarListas();

            cboMotivos.Items.Clear();

            cboMotivos.Items.Add("Preço muito alto");
            cboMotivos.Items.Add("Cliente desistiu");
            cboMotivos.Items.Add("Prazo incompatível");
            cboMotivos.Items.Add("Concorrente escolhido");

            if (cboMotivos.Items.Count > 0)
                cboMotivos.SelectedIndex = 0;

            // Ajusta botões e visibilidade conforme o papel do usuário logado
            AplicarPermissoes(); 

            ClienteRepository repo = new ClienteRepository();

            Dados.Clientes.Clear();

            foreach (Cliente cliente in repo.Listar())
            {
                Dados.Clientes.Add(cliente);
            }

            AtualizarListas();
        }

            private void CarregarClientes()
         {
            ClienteRepository repo =
                new ClienteRepository();
            // Limpa cache e preenche a lista global de clientes a partir do repositório
            Dados.Clientes.Clear();

            foreach (Cliente cliente in repo.Listar())
            {
                Dados.Clientes.Add(cliente);
            }
         }

        private void CarregarServicos()
        {
            ServicoRepository repo =
                new ServicoRepository();

            Dados.Servicos.Clear();

            foreach (Servico servico in repo.Listar())
            {
                Dados.Servicos.Add(servico);
            }
        }

        private void CarregarOrcamentos()
        {
            OrcamentoRepository repo =
                new OrcamentoRepository();

            Dados.Orcamentos.Clear();

            foreach (Orcamento orcamento in repo.Listar())
            {
                Dados.Orcamentos.Add(orcamento);
            }
        }



        private void AplicarPermissoes()
        {
            bool podeEditar = _usuarioLogado.Papel.Nome != "Visualizador";
            bool isAdmin = _usuarioLogado.Papel.Nome == "Admin";

            // Clientes
            btnCadastrar.Enabled = podeEditar;
            EditarCliente.Enabled = podeEditar;
            ExcluirCliente.Enabled = podeEditar;

            // Serviços
            btnCadastrarServico.Enabled = podeEditar;
            EditarServico.Enabled = podeEditar;
            ExcluirServico.Enabled = podeEditar;

            // Orçamentos
            btnAdicionarItem.Enabled = podeEditar;
            btnSalvarOrcamento.Enabled = podeEditar;
            btnAprovar.Enabled = podeEditar;
            btnReprovar.Enabled = podeEditar;
            btnExcluirOrcamento.Enabled = podeEditar;

            // O botão de gerenciar usuários só fica visível para Admin
            btnGerenciarUsuarios.Visible = isAdmin;
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

            // Monta o objeto Cliente e persiste via repositório
            Cliente cliente = new Cliente();

            cliente.Nome = txtNome.Text;
            cliente.Contato = txtContato.Text;

            ClienteRepository repo =
               new ClienteRepository();

            repo.Inserir(cliente); // insere no banco

            // Recarrega os dados e limpa os campos de entrada
            CarregarClientes();
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

            // Atualiza propriedades do cliente e persiste no banco
            cliente.Nome = txtNome.Text;
            cliente.Contato = txtContato.Text;

            ClienteRepository repo =
                new ClienteRepository();

            repo.Atualizar(cliente);

            // Recarrega para refletir mudanças
            CarregarClientes();

            AtualizarListas();

            _ = MessageBox.Show("Cliente atualizado.");
        }

        //EXCLUIR O CRIA
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

            // Remove o cliente selecionado do banco
            ClienteRepository repo =
                new ClienteRepository();

            repo.Excluir(cliente.Id);

            // Atualiza listas após exclusão
            CarregarClientes();

            AtualizarListas();

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

            // Ao selecionar um cliente, carrega seus dados nos campos para edição
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

            // Cria o serviço e salva no banco
            Servico servico =
                new Servico();

            servico.Nome =
                txtNomeServico.Text;

            servico.Preco =
                preco;

            ServicoRepository repo =
                new ServicoRepository();

            repo.Inserir(servico);

            // Recarrega e limpa campos
            CarregarServicos();

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
       lstServicos.SelectedItem as Servico;

            if (servico == null)
            {
                MessageBox.Show(
                    "Selecione um serviço."
                );
                return;
            }

            decimal preco;

            if (!decimal.TryParse(
                    txtPreco.Text,
                    out preco))
            {
                MessageBox.Show(
                    "Preço inválido."
                );
                return;
            }

            // Atualiza o serviço selecionado com novos valores
            servico.Nome =
                txtNomeServico.Text;

            servico.Preco =
                preco;

            ServicoRepository repo =
                new ServicoRepository();

            repo.Atualizar(servico);

            CarregarServicos();

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
                  lstServicos.SelectedItem as Servico;

            if (servico == null)
            {
                MessageBox.Show(
                    "Selecione um serviço."
                );
                return;
            }

            // Remove serviço do banco
            ServicoRepository repo =
                new ServicoRepository();

            repo.Excluir(servico.Id);

            CarregarServicos();

            AtualizarListas();

            MessageBox.Show(
                "Serviço removido."
            );
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

            // Adiciona item à lista temporária do orçamento e mostra na ListBox
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

            // Monta o orçamento com cliente e itens e salva no banco
            Orcamento o =
                new Orcamento();

            o.Cliente =
                (Cliente)cboCliente.SelectedItem;

            o.Itens =
                new List<ItemOrcamento>(
                    itensOrcamento);

            OrcamentoRepository repo =
                new OrcamentoRepository();

            repo.Inserir(o);
            Dados.Orcamentos.Add(o);

            // Mostra o total e limpa a lista temporária
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

            // Marca orçamento como aprovado, gera número de pedido e persiste
            o.Status = "Aprovado";

            o.NumeroPedido =
                Dados.ProximoPedido++;

            OrcamentoRepository repo =
                new OrcamentoRepository();

            repo.Atualizar(o);

            CarregarOrcamentos();

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

            // Marca orçamento como rejeitado com o motivo selecionado
            o.Status = "Rejeitado";

            o.MotivoRejeicao =
                cboMotivos.Text;

            OrcamentoRepository repo =
                new OrcamentoRepository();

            repo.Atualizar(o);

            CarregarOrcamentos();

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Orcamento o = lstOrcamentos.SelectedItem as Orcamento;

            if (o == null)
            {
                MessageBox.Show("Selecione um orçamento.");
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                "Tem certeza que deseja excluir este orçamento?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo
            );

            if (confirmacao != DialogResult.Yes)
                return;

            // Exclui orçamento e seus itens do banco
            OrcamentoRepository repo = new OrcamentoRepository();
            repo.Excluir(o.Id);

            CarregarOrcamentos();
            AtualizarListas();

            MessageBox.Show("Orçamento excluído.");
        }

        private void btnGerenciarUsuarios_Click(object sender, EventArgs e)
        {

            FormUsuarios form = new FormUsuarios(_usuarioLogado);
            form.ShowDialog();
        }
    }
}