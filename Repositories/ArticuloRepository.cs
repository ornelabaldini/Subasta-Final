using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Repositories
{
    internal class ArticuloRepository
    {
        readonly List<Entities.Articulo> articulos;
        private static int nextId = 1;
        public List<Entities.Articulo> Articulos { get => articulos; }
        public int SiguienteIdArticulo { get => nextId++; }
        public ArticuloRepository()
        {
            articulos = new List<Entities.Articulo>();
        }

        public void CrearArticulo(Entities.Articulo articulo)
        {
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
