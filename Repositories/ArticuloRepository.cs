using Subastas_Final.Entities;
using System.Collections.Generic;
using System.Linq;
using Subastas_Final.Interfaces;

namespace Subastas_Final.Repositories
{
    internal class ArticuloRepository : IArticuloRepository
    {
        private static List<Articulo> articulos = new List<Articulo>();

        private static int siguienteIdArticulo = 0;

        public List<Articulo> Articulos { get => articulos; }

        public ArticuloRepository()
        {
           
        }

        public void CrearArticulo(Articulo articulo)
        {
          
            siguienteIdArticulo++;
            articulo.IdArticulo = siguienteIdArticulo;
            articulos.Add(articulo);
        }

        public List<Articulo> ObtenerTodosArticulos()
        {
            return articulos;
        }

        public Articulo ObtenerArticuloPorId(int idArticulo)
        {
            return articulos.FirstOrDefault(a => a.IdArticulo == idArticulo);
        }

        public void EliminarArticulo(int idArticulo)
        {
            var articulo = ObtenerArticuloPorId(idArticulo);
            if (articulo != null)
            {
                articulos.Remove(articulo);
            }
        }

        public void ActualizarArticulo(Articulo articuloActualizado)
        {
            var articulo = ObtenerArticuloPorId(articuloActualizado.IdArticulo);
            if (articulo != null)
            {
                articulo.Nombre = articuloActualizado.Nombre;
            }
        }

    }
}
