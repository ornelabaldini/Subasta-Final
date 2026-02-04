using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Services
{
    internal class ArticuloService
    {
        readonly ArticuloRepository _articuloRepository;

        public ArticuloService()
        {
            _articuloRepository = new ArticuloRepository();
        }

        public bool CrearArticulo(Articulo nuevoArticulo)
        {
            nuevoArticulo.IdArticulo = _articuloRepository.SiguienteIdArticulo;
            _articuloRepository.CrearArticulo(nuevoArticulo);
            return true;
        }

        public List<Articulo> ObtenerTodosArticulos()
        {
            return _articuloRepository.ObtenerTodosArticulos();
        }

        public Articulo ObtenerArticuloPorId(int idArticulo)
        {
            return _articuloRepository.ObtenerArticuloPorId(idArticulo);
        }

        public bool ActualizarArticulo(Articulo articuloActualizado)
        {
            var articulo = _articuloRepository.ObtenerArticuloPorId(articuloActualizado.IdArticulo);
            if (articulo == null)
            {
                return false;
            }
            _articuloRepository.ActualizarArticulo(articuloActualizado);
            return true;
        }

        public bool EliminarArticulo(int idArticulo)
        {
            var articulo = _articuloRepository.ObtenerArticuloPorId(idArticulo);
            if (articulo == null)
            {
                return false;
            }
            _articuloRepository.EliminarArticulo(idArticulo);
            return true;
        }


    }
}
