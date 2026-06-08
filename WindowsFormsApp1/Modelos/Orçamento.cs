using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Modelos
{
    public class Orcamento
    {
        public Cliente Cliente { get; set; }

        public List<ItemOrcamento> Itens { get; set; }
            = new List<ItemOrcamento>();

        public string Status { get; set; } = "Pendente";

        public decimal Total()
        {
            return Itens.Sum(i => i.SubTotal());
        }
    }
}
