using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1.Modelos
{
    public class Orcamento
    {
        public Cliente Cliente { get; set; }

        public List<ItemOrcamento> Itens { get; set; } = new List<ItemOrcamento>();

        public string Status { get; set; } = "Pendente";

        public int? NumeroPedido { get; set; }

        public string MotivoRejeicao { get; set; }

        public decimal Total()
        {
            return Itens.Sum(i => i.SubTotal());
        }

        public override string ToString()
        {
            var totalFormatado = Total().ToString("C");
            if (Status == "Aprovado")
            {
                return $"{Cliente?.Nome} - {Status} - Pedido #{NumeroPedido} - {totalFormatado}";
            }

            if (Status == "Rejeitado")
            {
                return $"{Cliente?.Nome} - {Status} - {totalFormatado}";
            }

            return $"{Cliente?.Nome} - {Status} - {totalFormatado}";
        }
    }
}
