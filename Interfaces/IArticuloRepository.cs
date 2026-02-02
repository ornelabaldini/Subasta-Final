using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Interfaces
{
    internal interface IArticuloRepository
    {   void CrearArticulo(Entities.Articulo articulo);
        List<Entities.Articulo> ObtenerTodosArticulos();
        Entities.Articulo ObtenerArticuloPorId(int idArticulo);
        void EliminarArticulo(int idArticulo);
        void ActualizarArticulo(Entities.Articulo articuloActualizado);
    }
}
