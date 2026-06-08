using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Modelos
{
    public class ItemOrcamento
    {
        public Servico Servico { get; set; }
        public int Quantidade { get; set; }

        public decimal SubTotal()
        {
            return Servico.Preco * Quantidade;
        }
    }
}
