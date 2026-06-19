using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string SenhaHash { get; set; }
        public Papel Papel { get; set; }

        public override string ToString()
        {
            return $"{Nome} ({Papel?.Nome})";
        }
    }
}
