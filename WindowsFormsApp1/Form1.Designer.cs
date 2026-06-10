namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeServico = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.lstServicos = new System.Windows.Forms.ListBox();
            this.lstOrcamentos = new System.Windows.Forms.ListBox();
            this.btnCadastrarServico = new System.Windows.Forms.Button();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            this.lstItens = new System.Windows.Forms.ListBox();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.btnSalvarOrcamento = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.btnReprovar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contato:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 57);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(120, 22);
            this.txtNome.TabIndex = 2;
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(12, 153);
            this.txtContato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(120, 22);
            this.txtContato.TabIndex = 3;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(15, 215);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(99, 30);
            this.btnCadastrar.TabIndex = 4;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 16;
            this.lstClientes.Location = new System.Drawing.Point(12, 286);
            this.lstClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(147, 100);
            this.lstClientes.TabIndex = 5;
            this.lstClientes.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Servico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Preço:";
            // 
            // txtNomeServico
            // 
            this.txtNomeServico.Location = new System.Drawing.Point(299, 57);
            this.txtNomeServico.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomeServico.Name = "txtNomeServico";
            this.txtNomeServico.Size = new System.Drawing.Size(132, 22);
            this.txtNomeServico.TabIndex = 8;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(299, 153);
            this.txtPreco.Margin = new System.Windows.Forms.Padding(4);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(132, 22);
            this.txtPreco.TabIndex = 9;
            // 
            // lstServicos
            // 
            this.lstServicos.FormattingEnabled = true;
            this.lstServicos.ItemHeight = 16;
            this.lstServicos.Location = new System.Drawing.Point(303, 286);
            this.lstServicos.Margin = new System.Windows.Forms.Padding(4);
            this.lstServicos.Name = "lstServicos";
            this.lstServicos.Size = new System.Drawing.Size(128, 100);
            this.lstServicos.TabIndex = 10;
            // 
            // lstOrcamentos
            // 
            this.lstOrcamentos.FormattingEnabled = true;
            this.lstOrcamentos.ItemHeight = 16;
            this.lstOrcamentos.Location = new System.Drawing.Point(793, 57);
            this.lstOrcamentos.Margin = new System.Windows.Forms.Padding(4);
            this.lstOrcamentos.Name = "lstOrcamentos";
            this.lstOrcamentos.Size = new System.Drawing.Size(420, 84);
            this.lstOrcamentos.TabIndex = 18;
            // 
            // btnCadastrarServico
            // 
            this.btnCadastrarServico.Location = new System.Drawing.Point(299, 215);
            this.btnCadastrarServico.Margin = new System.Windows.Forms.Padding(4);
            this.btnCadastrarServico.Name = "btnCadastrarServico";
            this.btnCadastrarServico.Size = new System.Drawing.Size(100, 28);
            this.btnCadastrarServico.TabIndex = 11;
            this.btnCadastrarServico.Text = "button1";
            this.btnCadastrarServico.UseVisualStyleBackColor = true;
            this.btnCadastrarServico.Click += new System.EventHandler(this.btnCadastrarServico_Click);
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(543, 55);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(4);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(160, 24);
            this.cboCliente.TabIndex = 12;
            // 
            // cboServico
            // 
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(543, 106);
            this.cboServico.Margin = new System.Windows.Forms.Padding(4);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(160, 24);
            this.cboServico.TabIndex = 13;
            // 
            // numQuantidade
            // 
            this.numQuantidade.Location = new System.Drawing.Point(543, 153);
            this.numQuantidade.Margin = new System.Windows.Forms.Padding(4);
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(160, 22);
            this.numQuantidade.TabIndex = 14;
            // 
            // lstItens
            // 
            this.lstItens.FormattingEnabled = true;
            this.lstItens.ItemHeight = 16;
            this.lstItens.Location = new System.Drawing.Point(543, 215);
            this.lstItens.Margin = new System.Windows.Forms.Padding(4);
            this.lstItens.Name = "lstItens";
            this.lstItens.Size = new System.Drawing.Size(159, 116);
            this.lstItens.TabIndex = 15;
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Location = new System.Drawing.Point(516, 353);
            this.btnAdicionarItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(100, 28);
            this.btnAdicionarItem.TabIndex = 16;
            this.btnAdicionarItem.Text = "button1";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // btnSalvarOrcamento
            // 
            this.btnSalvarOrcamento.Location = new System.Drawing.Point(645, 353);
            this.btnSalvarOrcamento.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvarOrcamento.Name = "btnSalvarOrcamento";
            this.btnSalvarOrcamento.Size = new System.Drawing.Size(100, 28);
            this.btnSalvarOrcamento.TabIndex = 17;
            this.btnSalvarOrcamento.Text = "button2";
            this.btnSalvarOrcamento.UseVisualStyleBackColor = true;
            this.btnSalvarOrcamento.Click += new System.EventHandler(this.btnSalvarOrcamento_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(880, 241);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(234, 180);
            this.listBox1.TabIndex = 18;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // btnAprovar
            // 
            this.btnAprovar.Location = new System.Drawing.Point(850, 153);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(100, 28);
            this.btnAprovar.TabIndex = 19;
            this.btnAprovar.Text = "Aprovar";
            this.btnAprovar.UseVisualStyleBackColor = true;
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
            // 
            // btnReprovar
            // 
            this.btnReprovar.Location = new System.Drawing.Point(1049, 153);
            this.btnReprovar.Name = "btnReprovar";
            this.btnReprovar.Size = new System.Drawing.Size(100, 28);
            this.btnReprovar.TabIndex = 20;
            this.btnReprovar.Text = "Reprovar";
            this.btnReprovar.UseVisualStyleBackColor = true;
            this.btnReprovar.Click += new System.EventHandler(this.btnReprovar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 496);
            this.Controls.Add(this.btnReprovar);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.lstOrcamentos);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSalvarOrcamento);
            this.Controls.Add(this.btnAdicionarItem);
            this.Controls.Add(this.lstItens);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.btnCadastrarServico);
            this.Controls.Add(this.lstServicos);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtNomeServico);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstClientes);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtContato);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomeServico;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.ListBox lstServicos;
        private System.Windows.Forms.Button btnCadastrarServico;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.NumericUpDown numQuantidade;
        private System.Windows.Forms.ListBox lstItens;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Button btnSalvarOrcamento;
        private System.Windows.Forms.ListBox lstOrcamentos;
        private System.Windows.Forms.Button btnAprovar;
        private System.Windows.Forms.Button btnReprovar;
        private System.Windows.Forms.ListBox listBox1;
    }
}

   

