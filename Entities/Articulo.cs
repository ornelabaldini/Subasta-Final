
using System.Collections.Generic;

namespace Subastas_Final.Entities
{
    public class Articulo
    {
        private int idArticulo;
        private string nombre;
        public List<Puja> Pujas { get; set; } = new List<Puja>();

        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Articulo() { }

    }
}
