using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubliotecaMVC
{
    public class Autora
    {
        private string _nome { get; set; } //get resgatar, set publicar

        public Autora() { }

        public Autora(string nome)
        {
            Nome = nome;
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = $"{value} perfeita"; }
        }
        public List<Autora> ListaDeAutoras => new List<Autora>() { this};
    }
}
