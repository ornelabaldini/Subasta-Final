using Subastas_Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Repositories
{
    internal class ArticuloRepository
    {
        private static List<Articulo> articulos = new List<Articulo>();
        private static int siguienteIdArticulo = 1;

        public List<Articulo> Articulos { get => articulos; }
        public int SiguienteIdArticulo { get => siguienteIdArticulo++; }
        public ArticuloRepository()
        {
            // usamos la lista estática existente
        }

        public void CrearArticulo(Entities.Articulo articulo)
        {
            articulo.IdArticulo = SiguienteIdArticulo;
            articulos.Add(articulo);
        }

        public List<Entities.Articulo> ObtenerTodosArticulos()
        {
            return articulos;
        }
        public Entities.Articulo ObtenerArticuloPorId(int idArticulo)
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
        public void ActualizarArticulo(Entities.Articulo articuloActualizado)
        {
            var articulo = ObtenerArticuloPorId(articuloActualizado.IdArticulo);
            if (articulo != null)
            {
                articulo.Nombre = articuloActualizado.Nombre;
                articulo.Descripcion = articuloActualizado.Descripcion;
            }
        }

    }
}
