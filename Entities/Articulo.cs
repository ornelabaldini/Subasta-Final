using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Entities
{
    public class Articulo
    {
        private int idArticulo;
        private string nombre;
        private string descripcion;
       
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public Articulo() { }

        public override string ToString()
        {
            return $"Articulo ID: {idArticulo}, Nombre: {nombre}, Descripcion: {descripcion}";
        }
    }
}
