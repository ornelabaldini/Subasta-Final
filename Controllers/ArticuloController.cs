using Subastas_Final.Services;
using System.Collections.Generic;
using Subastas_Final.Entities;


namespace Subastas_Final.Controllers
{
    internal class ArticuloController
    {
        readonly ArticuloService _articuloService;

        public ArticuloController()
        {
            _articuloService = new ArticuloService();
        }

        public bool CrearArticulo(Articulo nuevoArticulo)
        {
            return _articuloService.CrearArticulo(nuevoArticulo);
        }

        public List<Articulo> ObtenerTodosArticulos()
        {
            return _articuloService.ObtenerTodosArticulos();
        }

        public Articulo ObtenerArticuloPorId(int idArticulo)
        {
            return _articuloService.ObtenerArticuloPorId(idArticulo);
        }

        public bool ActualizarArticulo(Articulo articuloActualizado)
        {
            return _articuloService.ActualizarArticulo(articuloActualizado);
        }

        public bool EliminarArticulo(int idArticulo)
        {
            return _articuloService.EliminarArticulo(idArticulo);
        }

    }
}
