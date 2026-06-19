using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Contato { get; set; }

        public override string ToString()
        {
            // Mostra apenas o nome ao exibir em listas
            return Nome;
        }
    }
}