using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Modelos
{
    public static class Dados
    {
        // BindingList notifica automaticamente os controles ligados
        public static BindingList<Cliente> Clientes = new BindingList<Cliente>();

        public static BindingList<Servico> Servicos = new BindingList<Servico>()
        {
            // Serviços pré-definidos
            new Servico { Nome = "Limpeza", Preco = 50m },
            new Servico { Nome = "Manutenção", Preco = 120m },
            new Servico { Nome = "Instalação", Preco = 200m }
        };

        public static BindingList<Orcamento> Orcamentos = new BindingList<Orcamento>();
    }
}
