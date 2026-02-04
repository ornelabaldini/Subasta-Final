using Subastas_Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Controllers
{
    internal class ArticuloController
    {
        readonly ArticuloService _articuloService;

        public ArticuloController()
        {
            _articuloService = new ArticuloService();
        }

        public bool CrearArticulo(Entities.Articulo nuevoArticulo)
        {
            return _articuloService.CrearArticulo(nuevoArticulo);
        }

        public List<Entities.Articulo> ObtenerTodosArticulos()
        {
            return _articuloService.ObtenerTodosArticulos();
        }

        public Entities.Articulo ObtenerArticuloPorId(int idArticulo)
        {
            return _articuloService.ObtenerArticuloPorId(idArticulo);
        }

        public bool ActualizarArticulo(Entities.Articulo articuloActualizado)
        {
            return _articuloService.ActualizarArticulo(articuloActualizado);
        }

        public bool EliminarArticulo(int idArticulo)
        {
            return _articuloService.EliminarArticulo(idArticulo);
        }

    }
}
