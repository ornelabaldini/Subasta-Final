using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subastas_Final.Entities;

namespace Subastas_Final.Interfaces
{
    internal interface IArticuloRepository
    {   void CrearArticulo(Articulo articulo);

        List<Articulo> ObtenerTodosArticulos();

        Articulo ObtenerArticuloPorId(int idArticulo);

        void EliminarArticulo(int idArticulo);

        void ActualizarArticulo(Articulo articuloActualizado);
    }
}
