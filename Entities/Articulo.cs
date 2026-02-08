
namespace Subastas_Final.Entities
{
    public class Articulo
    {
        private int idArticulo;
        private string nombre;
       
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Articulo() { }

        public override string ToString()
        {
            return $"Articulo ID: {idArticulo}, Nombre: {nombre}";
        }
    }
}
